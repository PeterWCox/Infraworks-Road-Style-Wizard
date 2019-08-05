using InfraworksJSON.Classes;
using InfraworksJSON.Classes._6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.Static_Classes
{
    public static class HelperClass
    {
        public static paramOverrides GenerateLeftSideFactorParamOverrides()
        {
            return new paramOverrides("LeftSideFactor", -1);
        }

        public static paramOverrides GenerateWidthParamOverrides(double width)
        {
            return new paramOverrides("Width", width);
        }



    }
}
