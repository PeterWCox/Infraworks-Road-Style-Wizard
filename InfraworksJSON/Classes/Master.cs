using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Classes
{
    public class Master
    {
        public Master(string city_name, string session_id, styles styles)
        {
            this.city_name = city_name;
            this.session_id = session_id;
            this.styles = styles;
        }

        public string city_name { get; set; }
        public string session_id { get; set; }
        public styles styles { get; set; }
    }
}
