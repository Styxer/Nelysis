using Nelysis.Core.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Controls;

namespace Nelysis.Core.Models
{
    public class NetworkComponents :BaseModel

    {
       
            
        public ComponentsTypes ComponentType { get; set; }
        public string Hostname { get; set; }
        public string Vendor { get; set; }
        public string TotalDayThroughput { get; set; }
        public bool HasRelatedEvent { get; set; }
   

        public static NetworkComponents Init(IList<string> data)
        {
            //ComponentsTypes componentsType;
            var isEnum = Enum.TryParse<ComponentsTypes>(data[3], out ComponentsTypes componentsType) && !int.TryParse(componentsType.ToString(), out _);


            var networkComponents = new NetworkComponents()
            {
                ID = data[0],
                IPAddress = data[1],
                MAC = data[2],
                ComponentType = isEnum ? componentsType : ComponentsTypes.None,
                Hostname = data[4],
                Vendor = data[5],
                TotalDayThroughput = data[6],
           

            };

            return networkComponents;
        }

        public override string ToString()
        {
            return $"{ID}|{IPAddress}|{MAC}|{((byte)ComponentType)}|{Hostname}|{Vendor}|{TotalDayThroughput}";
        }



        public NetworkComponents()
        {

        }

       
    }
}
