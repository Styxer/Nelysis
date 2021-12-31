using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nelysis.Core.Models
{
    public class Event : BaseModel
    {      
       
        public DateTime TimeAction { get; set; }
        public string Description { get; set; }
        public bool IsComponentTypeExternal { get; set; }

        public static Event Init(string[] data)
        {
            var @event = new Event()
            {
                ID = data[0],
                IPAddress = data[1],
                MAC = data[2],
                TimeAction = DateTime.Parse(data[3]),
                Description = data[4],

            };

            return @event;


        }

        public Event()
        {

        }
    }
}
