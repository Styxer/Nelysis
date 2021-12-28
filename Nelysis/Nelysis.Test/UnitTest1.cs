using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nelysis.Core;
using Nelysis.Core.Models;
using Nelysis.Services;
using Nelysis.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nelysis.Test
{
    [TestClass]
    public class UnitTest1
    {
        IFileService _IFileService;

        public UnitTest1()
        {
            _IFileService = new FileService();
        }

        [TestMethod]
        public void TestReadAsync()
        {
            var result = _IFileService.ProcessReadAsync(Paths.NetworkComponentsPath);

            foreach (var item in result)
            {

            }
           
        }

        [TestMethod]
        public void TestUpdateNetworkAsync()
        {
            var data = new List<string>() { "21", "192.168.1.401", "18:60:24:97:CE:06", "8", "HPI5DT", "2012", "4348823136312" };
            NetworkComponents NetworkComponents = NetworkComponents.Init(data);

            Task
            .Run(() => _IFileService.ModifyNetworkComponentTempFileAsync(NetworkComponents))
            .GetAwaiter()
            .GetResult();

           
        }

        [TestMethod]
        public void TestChainNetworkComponent()
        {
            _IFileService.ChainNetworkComponent();
        }
    }
}
