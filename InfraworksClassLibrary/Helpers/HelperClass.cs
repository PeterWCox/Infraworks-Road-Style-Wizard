using InfraworksJSON._5;
using InfraworksJSON.Classes;
using InfraworksJSON.Classes._4;
using InfraworksJSON.Classes._6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON.StaticClasses
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

        public static references CreateReference(string materialType, double width, bool isLHS, int ex_point)
        {
            List<paramOverrides> paramOverrides = new List<paramOverrides>();

            //If breadth = 0 return null;
            if (width == 0) { return null; }
            else
            {
                //if isLHS = true, add LHS paramOverrides 
                if (isLHS) { paramOverrides.Add(GenerateLeftSideFactorParamOverrides()); }

                // Set up width paramOverride
                paramOverrides.Add(GenerateWidthParamOverrides(width));

                //Set attachment parameters 
                attachment attachment = new attachment(0, ex_point, 1);

                //Create and return the reference object for the lane 
                references lane = new references(materialType, attachment, paramOverrides);
                return lane;
            }
        }

        public static references CreateReference(string materialType, double width, bool isLHS)
        {
            List<paramOverrides> paramOverrides = new List<paramOverrides>();

            //Set up width paramOverride 
            //if isLHS = true, add LHS paramOverrides 
            if (isLHS) { paramOverrides.Add(GenerateLeftSideFactorParamOverrides()); }
            paramOverrides.Add(GenerateWidthParamOverrides(width));

            //Create and return the reference object for the lane 
            references lane = new references(materialType, null, paramOverrides);
            return lane;
        }




    }
}
