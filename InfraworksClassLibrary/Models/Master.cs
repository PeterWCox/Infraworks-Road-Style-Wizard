using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksClassLibrary.Models
{
    public class Master
    {
        public Master()
        {

        }

        public string city_name { get; set; }
        public string session_id { get; set; }

        [JsonProperty("styles")]
        private Dictionary<string, component> AssemblyDictionary = new Dictionary<string, component>();

        public void AddComponent(string name, component component)
        {
            AssemblyDictionary.Add(name, component);
        }

    }
}
