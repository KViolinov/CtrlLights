using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLights.Data.Models
{
    public class TrafficLights
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeLaneStatus { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Lane { get; set; }
        public char LightStatus { get; set; }
        public string Busyness { get; set; }
    }
}
