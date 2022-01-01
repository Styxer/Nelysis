using Nelysis.Core.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Nelysis.Core
{
    public class TickerSymbolSelectedEvent : PubSubEvent<ObservableCollection<NetworkComponent>> { }
    
    
}
