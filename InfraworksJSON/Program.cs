using InfraworksJSON.Classes;
using InfraworksJSON.Classes._6;
using InfraworksJSON.Classes._4;
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
using InfraworksJSON.StaticClasses;
using static InfraworksJSON.StaticClasses.HelperClass;

namespace InfraworksJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //Need a method that:

            //a) Takes in a road name 
            //b) Takes in a description. 
            //c) Takes in a carriageway object (to assist with the creation)
            //d) Returns a 

            TestCode3();
        }

        public static void TestCode3()
        {

            //Export the JSON reference object for the following cross-section:  
            //2m Verge/7.3m CW/2.5m CR/7.3m CW/2m Verge 

            //First create all the parameter overrides for commonly used attributes 
            string laneName = "ComponentDefinition/Lane";
            string shoulderName = "ComponentDefinition/Shoulder";
            string roadName = "AR32";
            string fileName = @"C:\Users\pcox\Desktop\CSharpLOL.styles.json";

            //Define the list of references that make up the road cross-section 
            List<references> references = new List<references>()
            {
                //Central Reserve Bits 
                CreateReference(shoulderName, 1.25, true),  //0.5*2.5m LHS Central Reserve     => can be 0
                CreateReference(shoulderName, 1.25, false),  //0.5*2.5m RHS Central Reserve    => can be 0                     

                //LHS Ones 
                CreateReference(laneName, 3.65, false, 1),  //3.65m Lane 1 LHS => can be 0
                CreateReference(laneName, 3.65, false, 2),  //3.65m Lane 2 LHS => can be 0
                CreateReference(shoulderName, 2, false, 3),  //2m Verge LHS => can be 0

                //RHS Ones
                CreateReference(laneName, 3.65, true, 0),  //3.65m Carriageway RHS 
                CreateReference(laneName, 3.65, true, 5),  //3.65m Carriageway RHS 
                CreateReference(shoulderName, 2, true, 6),  //2m Verge RHS 
            };

            //Instantiate the assembly object 
            var assembly = new Component();
            assembly.styleType = "Component";
            assembly.name = roadName;
            assembly.description = "Dual 7.3m Carriageways with 2m Verges and 2.5m Reserve";
            assembly.category = "assembly";
            assembly.showMarking = true;
            assembly.revision = 1337;
            assembly.references = references;

            //Step 3 = Create the dictonary of styles
            var stylesDictionary = new Dictionary<string, Component>()
             {
                {"Component/Custom/abcdef", assembly},
            };

            //Step 4 Instantiate the "Master" object 
            Master m = new Master("HAL", "{0D947B14-261F-4D54-AEC5-289040C67073}", stylesDictionary);

            //Step 4 - Write thge JSON to the file 
            string json = JsonConvert.SerializeObject(m,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            File.WriteAllText(fileName, json);
            Console.WriteLine(json);
        }
    }
}
