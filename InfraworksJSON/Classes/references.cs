using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes
{
    public class references
    {
        public references(string def, List<paramOverrides> paramOverrides, attachment attachment)
        {
            this.def = def;
            this.paramOverrides = paramOverrides;
            this.attachment = attachment;
        }

        public string def { get; set; }
        public List<paramOverrides> paramOverrides { get; set; }
        public attachment attachment { get; set; }

    }
}
