using System;
using System.Collections.Generic;
using System.Text;

namespace Nelysis.Core
{
    public static class Paths
    {
        private const string dataFolder
            = @"Data\";

        private const string tempdataFolder
          = @"TempData\"; 

        private const string networkComponents
            = @"network_components.txt";

        private const string events
           = @"events.txt";

        private const string basePath =
            @"C:\Users\ofir_roz\Desktop\Nelysis_Task\";

        public static string NetworkComponentsPath
        {
            get => System.IO.Path.Combine(basePath, dataFolder,  networkComponents);
        }
        public static string NetworkComponentsFile
        {
            get => networkComponents;
        }

        public static string EventsPath
        {
            get => System.IO.Path.Combine(basePath, dataFolder, events);
        }

        public static string DataFolder
        {
            get => System.IO.Path.Combine(basePath, dataFolder);
        }

        public static string TempDataFolder
        {
            get => System.IO.Path.Combine(basePath, tempdataFolder);
        }
    }
}
