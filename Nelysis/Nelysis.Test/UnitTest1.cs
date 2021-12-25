using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = _IFileService.ProcessReadAsync
            (@"C:\Users\ofir_roz\Desktop\Nelysis_Task\Data\network_components.txt");

            foreach (var item in result)
            {

            }
           
        }
    }
}
