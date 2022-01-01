using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nelysis.Core.Models
{
    public class BaseModel :BindableBase
    {
      

        private string _id;
        public string ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { SetProperty(ref _IPAddress, value); }
        }

        private string _mac;
        public string MAC
        {
            get { return _mac; }
            set { SetProperty(ref _mac, value); }
        }
    }
}
