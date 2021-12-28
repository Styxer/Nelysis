using Nelysis.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nelysis.Services.Interfaces
{
    public interface IFileService
    {

        IEnumerable<NetworkComponents> ProcessReadAsync(string filePath);
        static int  RowsInChuckSize { get;   }

        Task ModifyNetworkComponentTempFileAsync(NetworkComponents networkComponents);

        Task ChainNetworkComponent();


    }
}

