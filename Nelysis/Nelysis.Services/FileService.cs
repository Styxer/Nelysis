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
using System.Windows.Shapes;

namespace Nelysis.Services
{
    public class FileService : IFileService
    {
        private static readonly int rowsInChuckSize = 10;
        IEnumerable<NetworkComponents> IFileService.ProcessReadAsync(string filePath)
        {
            return Task
             .Run(() => AsyncContext.Run(() => ProcessListAsync(filePath)))
             .GetAwaiter()
             .GetResult();
        }
       

        public  async Task<IEnumerable<NetworkComponents>> ProcessListAsync(string filePath)
        {

            return await Task
                .Run(() => ReadAllTextAsync(filePath))
                .GetAwaiter()
                .GetResult()
                .ToListAsync();
        }

        private static async IAsyncEnumerable<NetworkComponents> ReadAllTextAsync(string filePath)
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
                    sb.AppendLine(line);
                    if (splitted.Length == 7)//TODO
                    {
                        if (counter % rowsInChuckSize == 0)
                        {
                            var chunkName = $"_{fromChunkNum}_{toChunkNum+1}.txt";

                            await WriteCharacters(sb, chunkName)
                                .ContinueWith(x => sb.Clear());
                            fromChunkNum = counter;
                        }
                        else
                        {

                        }
                        yield return NetworkComponents.Init(splitted);
                    }
                    toChunkNum = counter++;
                }

                
            }
        }

        private static async Task WriteCharacters(StringBuilder items, string chunkName)
        {
            var path = System.IO.Path.Combine(Paths.TempDataFolder, chunkName);

            if (!File.Exists(path))
            {
                if (!Directory.Exists(Paths.TempDataFolder))
                {
                    Directory.CreateDirectory(Paths.TempDataFolder);
                }
                using (var writer = new StreamWriter(path, append: false))
                {
                    await writer.WriteAsync(items.ToString());
                } 
            }
        }



    }
}
