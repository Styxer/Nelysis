using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nelysis.Core.Models
{
    public class Event
    {
        public string ID { get; set; }
        public string SourceIP { get; set; }
        public string SourceMAC { get; set; }
        public DateTime TimeAction { get; set; }
        public string Description { get; set; }

        public static Event Init(string[] data)
        {
            var @event = new Event()
            {
                ID = data[0],
                SourceIP = data[1],
                SourceMAC = data[2],
                TimeAction = DateTime.Parse(data[3]),
                Description = data[4],

            };

            return @event;


        }
    }
}
