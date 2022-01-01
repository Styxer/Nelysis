using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nelysis.Services.Interfaces
{
    interface IEventAggregator
    {
        TEventType GetEvent<TEventType>() where TEventType : EventBase;
    }
}
