using InfraworksJSON.Classes;
using InfraworksJSON.Static_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            const string laneName = "ComponentDefinition/Shoulder";
            const string shoulderName = "ComponentDefinition/Shoulder";

            //Export the JSON reference object for the following cross-section:  
            //2m Verge/7.3m CW/2.5m CR/7.3m CW/2m Verge 
            //Create all the necessary parameterOverrides 
            paramOverrides lhsFactorlhs = HelperClass.GenerateLeftSideFactorParamOverrides();

            paramOverrides _CRWidth = HelperClass.GenerateWidthParamOverrides(1.25);
            paramOverrides _3650LaneWidth = HelperClass.GenerateWidthParamOverrides(3.650);
            paramOverrides _VergeWidth = HelperClass.GenerateWidthParamOverrides(2);


            //1 CR LHS Reference 
            string lhsCR_Ref = laneName;
            List<paramOverrides> lhsCR_ParamOverrides = new List<paramOverrides>() { _CRWidth, lhsFactorlhs };
            attachment lhsCR_Attachment = null;

            references lhsCR = new references(lhsCR_Ref, lhsCR_ParamOverrides, lhsCR_Attachment);






        }




    }




}
