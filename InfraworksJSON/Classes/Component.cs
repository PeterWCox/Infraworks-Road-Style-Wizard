using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes
{
    public class Component
    {
        public string styleType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public bool showMarking { get; set; }
        public int revision { get; set; }
        public List<references> references {get; set; }

    }
}
