using InfraworksJSON.Classes;
using InfraworksJSON.Classes._6;
using InfraworksJSON.Classes._4;
using InfraworksJSON.Static_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraworksJSON._5;
using InfraworksJSON.Classes._3;
using InfraworksJSON.Classes._1;
using Newtonsoft.Json.Linq;

namespace InfraworksJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }


        public void OutputRoadAssemblyToJSON()
        {              
            const string laneName = "ComponentDefinition/Lane";
            const string shoulderName = "ComponentDefinition/Shoulder";

            //Export the JSON reference object for the following cross-section:  
            //2m Verge/7.3m CW/2.5m CR/7.3m CW/2m Verge 


            //First create all the parameter overrides for commonly used attributes 
            paramOverrides lhsFactorlhs = HelperClass.GenerateLeftSideFactorParamOverrides();
            paramOverrides _CRWidth = HelperClass.GenerateWidthParamOverrides(1.25);
            paramOverrides _3650LaneWidth = HelperClass.GenerateWidthParamOverrides(3.650);
            paramOverrides _VergeWidth = HelperClass.GenerateWidthParamOverrides(2);

            //Define the list of references that make up the road cross-section 
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

            //Lane 1 RHS Reference
            List<paramOverrides> rhsLane1_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane1_Attachment = new attachment(0, 1, 1);
            references.Add(new references(laneName, rhsLane1_ParamOverrides, rhsLane1_Attachment));

            //Lane 2 RHS Reference
            List<paramOverrides> rhsLane2_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane2_Attachment = new attachment(0, 5, 1);
            references.Add(new references(laneName, rhsLane2_ParamOverrides, rhsLane2_Attachment));

            //Verge RHS Reference
            List<paramOverrides> rhsVerge_ParamOverrides = new List<paramOverrides>() { _VergeWidth };
            attachment rhsVerge_Attachment = new attachment(0, 6, 1);
            references.Add(new references(laneName, rhsVerge_ParamOverrides, rhsVerge_Attachment));


            //Now create the assembly object 
            var assembly = new Component();
            assembly.styleType = "Component";
            assembly.name = "Two Lanes";
            assembly.description = "LALALALALAALAGOTOBEDLALALA.";
            assembly.category = "assembly";
            assembly.showMarking = true;
            assembly.revision = 0;
            assembly.references = references;

            //Step 3 = Create the styles object 

            var stylesDictionary = new Dictionary<string, Component>()
             {
                {"Component/Custom/test12345", assembly},
                {"Component/Custom/XXXXXX", assembly},
                {"Component/Custom/YYYYYY", assembly},
            };

            //Step 4 - Write thge JSON to the file 

            //StringBuilder s = new StringBuilder();
            //s.AppendLine("{");
            //s.AppendLine(@"""city_name"": ""testModePC"",");
            //s.AppendLine(@"""session_id"": ""{926F1706-0DD5-4C67-9896-547C206B1740}"",");
            //s.AppendLine(@"""styles"":");

            Master m = new Master("Redmon", "12345", stylesDictionary);

            string json = JsonConvert.SerializeObject(m,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });




            //s.Append(json);
            //Console.WriteLine(s);

            File.WriteAllText(@"C:\Users\pcox\Desktop\JSONLETSGOGOGO.styles.json", json);
            Console.WriteLine(json);






        }



        public void TestCode2()
        {
            const string laneName = "ComponentDefinition/Lane";
            const string shoulderName = "ComponentDefinition/Shoulder";

            //Export the JSON reference object for the following cross-section:  
            //2m Verge/7.3m CW/2.5m CR/7.3m CW/2m Verge 


            //First create all the parameter overrides for commonly used attributes 
            paramOverrides lhsFactorlhs = HelperClass.GenerateLeftSideFactorParamOverrides();
            paramOverrides _CRWidth = HelperClass.GenerateWidthParamOverrides(1.25);
            paramOverrides _3650LaneWidth = HelperClass.GenerateWidthParamOverrides(3.650);
            paramOverrides _VergeWidth = HelperClass.GenerateWidthParamOverrides(2);

            //Define the list of references that make up the road cross-section 
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

            //Lane 1 RHS Reference
            List<paramOverrides> rhsLane1_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane1_Attachment = new attachment(0, 1, 1);
            references.Add(new references(laneName, rhsLane1_ParamOverrides, rhsLane1_Attachment));

            //Lane 2 RHS Reference
            List<paramOverrides> rhsLane2_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane2_Attachment = new attachment(0, 5, 1);
            references.Add(new references(laneName, rhsLane2_ParamOverrides, rhsLane2_Attachment));

            //Verge RHS Reference
            List<paramOverrides> rhsVerge_ParamOverrides = new List<paramOverrides>() { _VergeWidth };
            attachment rhsVerge_Attachment = new attachment(0, 6, 1);
            references.Add(new references(laneName, rhsVerge_ParamOverrides, rhsVerge_Attachment));


            //Now create the assembly object 
            var assembly = new Component();
            assembly.styleType = "Component";
            assembly.name = "Two Lanes";
            assembly.description = "LALALALALAALAGOTOBEDLALALA.";
            assembly.category = "assembly";
            assembly.showMarking = true;
            assembly.revision = 0;
            assembly.references = references;

            //Step 3 = Create the styles object 

            var stylesDictionary = new Dictionary<string, Component>()
             {
                {"Component/Custom/test12345", assembly},
                {"Component/Custom/XXXXXX", assembly},
                {"Component/Custom/YYYYYY", assembly},
            };

            //Step 4 - Write thge JSON to the file 

            //StringBuilder s = new StringBuilder();
            //s.AppendLine("{");
            //s.AppendLine(@"""city_name"": ""testModePC"",");
            //s.AppendLine(@"""session_id"": ""{926F1706-0DD5-4C67-9896-547C206B1740}"",");
            //s.AppendLine(@"""styles"":");

            Master m = new Master("Redmon", "12345", stylesDictionary);

            string json = JsonConvert.SerializeObject(m,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });




            //s.Append(json);
            //Console.WriteLine(s);

            File.WriteAllText(@"C:\Users\pcox\Desktop\JSONLETSGOGOGO.styles.json", json);
            Console.WriteLine(json);
        }

        public void TestCodeX()
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

            //Lane 1 RHS Reference
            List<paramOverrides> rhsLane1_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane1_Attachment = new attachment(0, 1, 1);
            references.Add(new references(laneName, rhsLane1_ParamOverrides, rhsLane1_Attachment));

            //Lane 2 RHS Reference
            List<paramOverrides> rhsLane2_ParamOverrides = new List<paramOverrides>() { _3650LaneWidth };
            attachment rhsLane2_Attachment = new attachment(0, 5, 1);
            references.Add(new references(laneName, rhsLane2_ParamOverrides, rhsLane2_Attachment));

            //Verge RHS Reference
            List<paramOverrides> rhsVerge_ParamOverrides = new List<paramOverrides>() { _VergeWidth };
            attachment rhsVerge_Attachment = new attachment(0, 6, 1);
            references.Add(new references(laneName, rhsVerge_ParamOverrides, rhsVerge_Attachment));


            //Step 2 = Create the assembly object 
            Assembly assembly = new Assembly();
            assembly.styleType = "Component";
            assembly.name = "Two Lanes";
            assembly.description = "LALALALALAALAGOTOBEDLALALA.";
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
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });



            Console.WriteLine(json);

        }
    }
}
