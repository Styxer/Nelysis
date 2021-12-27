using Nelysis.Core.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nelysis.Core.Models
{
    public class NetworkComponents
    {
        public string ID { get; set; }
        public string IPAddress { get; set; }
        public string MAC { get; set; }
        //public int ID { get; set; }
        public ComponentsTypes ComponentType { get; set; }
        public string Hostname { get; set; }
        public string Vendor { get; set; }
        public string TotalDayThroughput { get; set; }

        public static NetworkComponents Init(IList<string> data)
        {
            ComponentsTypes componentsType;
            Enum.TryParse<ComponentsTypes>(data[3], out componentsType);
            var networkComponents = new NetworkComponents()
            {
                ID = data[0],
                IPAddress = data[1],
                MAC = data[2],
                ComponentType = componentsType,
                Hostname = data[4],
                Vendor = data[5],
                TotalDayThroughput = data[6],

            };

            return networkComponents;
        }

        

        public NetworkComponents()
        {

        }

       
    }
}
