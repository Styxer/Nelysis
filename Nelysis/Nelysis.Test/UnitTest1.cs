using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nelysis.Core;
using Nelysis.Services;
using Nelysis.Services.Interfaces;

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
        public void TestMethod1()
        {
            var result = _IFileService.ProcessReadAsync(Paths.NetworkComponentsPath);

            foreach (var item in result)
            {

            }
           
        }
    }
}
