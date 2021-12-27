using Nelysis.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nelysis.Services.Interfaces
{
    public interface IFileService
    {

        IEnumerable<NetworkComponents> ProcessReadAsync(string filePath);

        
    }
}

