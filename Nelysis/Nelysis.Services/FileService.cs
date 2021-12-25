using Nelysis.Core.Models;
using Nelysis.Services.Interfaces;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nelysis.Services
{
    public class FileService : IFileService
    {

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
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    var splitted = line.Split('|');
                    if(splitted.Length ==7)
                    {
                        yield return NetworkComponents.Init(splitted);
                    }
                }

                
            }
        }

        
    }
}
