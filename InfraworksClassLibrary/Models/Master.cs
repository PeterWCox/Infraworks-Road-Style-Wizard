using InfraworksJSON.Classes._3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes._1
{
    public class Master
    {
        public Master(string city_name, string session_id, Dictionary<string, Component> assemblyDictionary)
        {
            this.city_name = city_name;
            this.session_id = session_id;
            AssemblyDictionary = assemblyDictionary;
        }

        public string city_name { get; set; }
        public string session_id { get; set; }

        [JsonProperty("styles")]
        public Dictionary<string, Component> AssemblyDictionary { get; set; }
    }
}
