using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes
{
    public class styles
    {
        public styles(Assembly assemblies)
        {
            this.assemblies = assemblies;
        }

        [JsonProperty("Component/Custom/test12345")]
        public Assembly assemblies { get; set; }
    }
} 
