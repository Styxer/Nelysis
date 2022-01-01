using Nelysis.Core;
using Nelysis.Core.Models;
using Nelysis.Services.Interfaces;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;


namespace Nelysis.Services
{




    public class FileService<T> : IFileService<T> where T : class, new() 
    {
        public static int RowsInChuckSize { get => 10; }
        IEnumerable<T> IFileService<T>.ProcessReadAsync(string filePath)
        {
            return Task
             .Run(() => AsyncContext.Run(() => ProcessListAsync(filePath)))
             .GetAwaiter()
             .GetResult();
        }

        async Task IFileService<T>.ChainNetworkComponent()
        {
            // var inputFilePaths =   //Directory.GetFiles();
            var inputFilePaths = new DirectoryInfo(Paths.TempDataFolder)
                .GetFiles()
                .OrderBy(x => x.CreationTime);
            var path = typeof(T) == typeof(NetworkComponent) ? Paths.NetworkComponentsPath : Paths.EventsPath;
            using (var outputStream = File.Create(path))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath.FullName))
                    {                      
                       await inputStream.CopyToAsync(outputStream);
                    }
                }
            }
        }
     
        async Task IFileService<T>.ModifyNetworkComponentTempFileAsync(T item)
        {
            var val = (BaseModel)Convert.ChangeType(item, typeof(BaseModel));

            int id = Convert.ToInt32(val.ID);
            int from = id - (id % RowsInChuckSize) +1;
            int to = from + RowsInChuckSize - 2;
            var chunkName = $"{from}_{to}.txt";


            var result = await ProcessListAsync(Path.Combine(Paths.TempDataFolder, chunkName)) as IEnumerable<BaseModel>;
            result = result.Select(x => x.ID == val.ID ? val : x);



            var items =    string.Join(Environment.NewLine, result);



            await WriteCharacters(items, chunkName);
        }

        private void DelteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path); 
            }
        }

        


        private  async Task<IEnumerable<T>> ProcessListAsync(string filePath)
        {

            return await Task
                .Run(() => ReadAllTextAsync(filePath))
                .GetAwaiter()
                .GetResult()
                .ToListAsync();
        }

        private static async IAsyncEnumerable<T> ReadAllTextAsync(string filePath, bool doSplit = true)
        {
            var sb = new StringBuilder();
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                int counter = 1, fromChunkNum = 1, toChunkNum = 1;
                string line;
                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    var splitted = line.Split('|');
                  
                   // if (splitted.Length == 7)//TODO
                    {
                        sb.AppendLine(line);
                        if (doSplit)
                        {
                            if (counter % RowsInChuckSize == 0)
                            {
                                toChunkNum = toChunkNum == 9 ? toChunkNum + 1 : toChunkNum;//TODO: REMOVE THIS STUPID HACK
                                var chunkName = $"{fromChunkNum}_{toChunkNum}.txt";

                                await WriteCharacters(sb.ToString(), chunkName)
                                    .ContinueWith(x => sb.Clear());
                                fromChunkNum = counter+1;
                            } 
                        }

                        yield return typeof(T) == typeof(NetworkComponent) ?
                            (T)Convert.ChangeType(NetworkComponent.Init(splitted), typeof(T)) :
                            (T)Convert.ChangeType(Event.Init(splitted), typeof(T));
                    }
                    toChunkNum = counter++;
                }

                
            }
        }

        private static async Task WriteCharacters(string items, string chunkName)
        {
            var path = Path.Combine(Paths.TempDataFolder, chunkName);
            
            if (!Directory.Exists(Paths.TempDataFolder))
            {
                Directory.CreateDirectory(Paths.TempDataFolder);
            }
            using (var writer = new StreamWriter(path, append: false))
            {
                await writer.WriteAsync(items);
            } 
            
        }

     
    }
}
