using InfraworksJSON.Classes;
using InfraworksJSON.Static_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraworksJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            const string laneName = "ComponentDefinition/Lane";
            const string shoulderName = "ComponentDefinition/Shoulder";

            //Export the JSON reference object for the following cross-section:  
            //2m Verge/7.3m CW/2.5m CR/7.3m CW/2m Verge 
            //Create all the necessary parameterOverrides 

            //References
            // ==>def  
            // ==>attachment
            // ==>List<ParamOverrides>

            paramOverrides lhsFactorlhs = HelperClass.GenerateLeftSideFactorParamOverrides();

            paramOverrides _CRWidth = HelperClass.GenerateWidthParamOverrides(1.25);
            paramOverrides _3650LaneWidth = HelperClass.GenerateWidthParamOverrides(3.650);
            paramOverrides _VergeWidth = HelperClass.GenerateWidthParamOverrides(2);


            List<references> references = new List<references>();

            //CR LHS Reference 
            List<paramOverrides> lhsCR_ParamOverrides = new List<paramOverrides>() { _CRWidth, lhsFactorlhs };
            attachment lhsCR_Attachment = null;
            references.Add(new references(shoulderName, lhsCR_ParamOverrides, lhsCR_Attachment));

            // CR RHS Reference
            List<paramOverrides> rhsCR_ParamOverrides = new List<paramOverrides>() { _CRWidth };
            attachment rhsCR_Attachment = null;
            references.Add(new references(shoulderName, rhsCR_ParamOverrides, rhsCR_Attachment));

            //Lane 1 LHS Reference
            List<paramOverrides> lhsLane1_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth, lhsFactorlhs };
            attachment lhsLane1_Attachment = new attachment(0, 0, 1);
            references.Add(new references(laneName, lhsLane1_ParamOverrides, lhsLane1_Attachment));

            //Lane 2 LHS Reference
            List<paramOverrides> lhsLane2_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth, lhsFactorlhs };
            attachment lhsLane2_Attachment = new attachment(0, 2, 1);
            references.Add(new references(laneName, lhsLane2_ParamOverrides, lhsLane2_Attachment));

            //Verge LHS Reference
            List<paramOverrides> lhsVerge_ParamOverrides = new List<paramOverrides>() { _VergeWidth, lhsFactorlhs };
            attachment lhsVerge_Attachment = new attachment(0, 3, 1);
            references.Add(new references(laneName, lhsVerge_ParamOverrides, lhsVerge_Attachment));


            //Step 2 = Create the assembly object 
            Assembly assembly = new Assembly();
            assembly.styleType = "Component";
            assembly.name = "Two Lanes";
            assembly.description = "A two lane road.";
            assembly.category = "assembly";
            assembly.showMarking = true;
            assembly.revision = 0;
            assembly.references = references;

            List<Assembly> ass = new List<Assembly>();
            ass.Add(assembly);

            //Step 3 = Create the master object
            styles styles = new styles(assembly);
            List<styles> s = new List<styles>();
            s.Add(styles);

            Master m = new Master("INFRAWORKSUCKSASS", "{926F1706-0DD5-4C67-9896-547C206B1740}", styles);

            //Convert to JSON
            string json = JsonConvert.SerializeObject(m, 
                Newtonsoft.Json.Formatting.Indented, 
                new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Ignore});

            File.WriteAllText(@"C:\Users\pcox\Desktop\OutputJSON.styles.json", json);

            Console.WriteLine(json);



        }




    }




}
