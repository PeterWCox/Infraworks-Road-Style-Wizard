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
        public Master()
        {

        }

        public string city_name { get; set; }
        public string session_id { get; set; }

        [JsonProperty("styles")]
        private Dictionary<string, Component> AssemblyDictionary = new Dictionary<string, Component>();

        public void AddComponent(string name, Component component)
        {
            AssemblyDictionary.Add(name, component);
        }

    }
}
