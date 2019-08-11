using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksClassLibrary.Models
{
    public class references
    {
        public references()
        {
        }

        public references(string def, attachment attachment, List<paramOverrides> paramOverrides)
        {
            this.def = def;
            this.attachment = attachment;
            this.paramOverrides = paramOverrides;
        }

        public string def { get; set; }
        public attachment attachment { get; set; }
        public List<paramOverrides> paramOverrides { get; set; }

        public void PrintReferenceData()
        {
            if (attachment != null)
            {

            }

            
        }

    }
}
