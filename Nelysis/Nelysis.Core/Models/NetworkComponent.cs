using Nelysis.Core.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Controls;

namespace Nelysis.Core.Models
{
    public class NetworkComponent :BaseModel

    {
        private ComponentsTypes _componentType;
        public ComponentsTypes ComponentType
        {
            get { return _componentType; }
            set { SetProperty(ref _componentType, value); }
        }

        private string _hostname;
        public string Hostname
        {
            get { return _hostname; }
            set { SetProperty(ref _hostname, value); }
        }

        private string _vendor;
        public string Vendor
        {
            get { return _vendor; }
            set { SetProperty(ref _vendor, value); }
        }

        private string _totalDayThroughput;
        public string TotalDayThroughput
        {
            get { return _totalDayThroughput; }
            set { SetProperty(ref _totalDayThroughput, value); }
        }

        private bool _hasRelatedEvent;
        public bool HasRelatedEvent
        {
            get { return _hasRelatedEvent; }
            set { SetProperty(ref _hasRelatedEvent, value); }
        }

        public static NetworkComponent Init(IList<string> data)
        {
            //ComponentsTypes componentsType;
            var isEnum = Enum.TryParse<ComponentsTypes>(data[3], out ComponentsTypes componentsType) && !int.TryParse(componentsType.ToString(), out _);


            var networkComponents = new NetworkComponent()
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



        public NetworkComponent()
        {

        }

       
    }
}
