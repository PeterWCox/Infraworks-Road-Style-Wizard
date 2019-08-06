using InfraworksJSON._5;
using InfraworksJSON.Classes._6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes._4
{
    public class references
    {
        public references(string def, attachment attachment, List<paramOverrides> paramOverrides)
        {
            this.def = def;
            this.attachment = attachment;
            this.paramOverrides = paramOverrides;
        }

        public string def { get; set; }
        public attachment attachment { get; set; }
        public List<paramOverrides> paramOverrides { get; set; }

    }
}
