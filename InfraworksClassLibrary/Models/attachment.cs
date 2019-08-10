using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON._5
{
    public class attachment
    {
        public attachment(int point, int ex_comp, int ex_point)
        {
            this.point = point;
            this.ex_comp = ex_comp;
            this.ex_point = ex_point;
        }

        public int point { get; set; }
        public int ex_comp { get; set; }
        public int ex_point { get; set; }
    }
}
