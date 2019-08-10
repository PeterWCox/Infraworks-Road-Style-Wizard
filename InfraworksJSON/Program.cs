using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using InfraworksJSON.Classes._3;
using InfraworksJSON.Classes._1;
using static InfraworksClassLibrary.Helpers.CrossSections;

namespace InfraworksJSON
{
    class Program
    {
        //TODO - Catch when width of road < 0.1m as infraworks hates this
        static void Main(string[] args)
        {
            //Global+ProjectData 
            string fileName = @"C:\Users\pcox\Desktop\C#TestFilesNEWWWW.styles.json";

            //Add each component to the styles dictionary
            var stylesDictionary = new Dictionary<string, Component>()
             {
                { "Component/Custom/TC01-SingleCW", Test1_SingleCwWith2mVerges()},
                { "Component/Custom/TC02-DualCWWithCentralRes", Test2_DualCwWith2mVerges()},
            };

            //Step 4 Instantiate the "Master" object 
            Master m = new Master();
            m.city_name = "testModePC";
            m.session_id = "{0D947B14-261F-4D54-AEC5-289040C67073}";
            m.AddComponent("Component/Custom/TC01-SingleCW", Test1_SingleCwWith2mVerges());
            m.AddComponent("Component/Custom/TC02-DualCWWithCentralRes", Test2_DualCwWith2mVerges());


            //Step 4 - Write the JSON to the file 
            string json = JsonConvert.SerializeObject(m,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            File.WriteAllText(fileName, json);
            Console.WriteLine(json);
            Console.WriteLine();
            Console.WriteLine();
        }






        
       
    }

   
}
