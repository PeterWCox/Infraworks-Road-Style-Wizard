using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksClassLibrary
{
    public class ReferenceModel
    {
        public ReferenceModel(string def, double width, bool isLHS)
        {
            this.def = def;
            this.width = width;
            this.isLHS = isLHS;
        }

        public string def { get; set; }
        public double width { get; set; }
        public bool isLHS { get; set; }
    }
}
