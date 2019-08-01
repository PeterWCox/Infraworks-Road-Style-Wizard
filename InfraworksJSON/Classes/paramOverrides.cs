using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes
{
    public class paramOverrides
    {
        public paramOverrides(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        public string name { get; set; }
        public double value { get; set; }
    }
}
