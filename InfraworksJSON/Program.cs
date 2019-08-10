using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using InfraworksJSON.Classes._3;
using InfraworksJSON.Classes._1;
using InfraworksJSON.Models;

namespace InfraworksJSON
{
    class Program
    {
        //TODO - Catch when width of road < 0.1m as infraworks hates this
        static void Main(string[] args)
        {
            //ProjectData 
            string laneName = "ComponentDefinition/Lane";
            string shoulderName = "ComponentDefinition/Shoulder";
            int revision = 1;
            bool showMarking = true;
            string description = "Dual 7.3m Carraigeways with 2m Verges and 2.5m Central Reserve.";
            string roadName = "AR69";
            string stylesDictionaryComponentName = "Component/Custom/abcdef";
            string fileName = @"C:\Users\pcox\Desktop\C#TestFiles.styles.json";

            //Create the road and return the List<references> needed to populate the references object. 
            Road r = new Road();
            r.AddComponent(shoulderName, 2.5, true);
            r.AddComponent(laneName, 6, true);
            r.AddComponent(laneName, 6, true);
            r.AddComponent(laneName, 6, true);
            r.AddComponent(shoulderName, 5.12, false);
            r.AddComponent(shoulderName, 3, false);
            r.AddComponent(laneName, 2, false);
            r.AddComponent(laneName, 2, false);
            r.AddComponent(shoulderName, 0, false);
            r.AddComponent(shoulderName, 0, false);

            //Instantiate the component object 
            var component = new Component();
            component.styleType = "Component";
            component.name = roadName;
            component.description = description;
            component.category = "assembly";
            component.showMarking = showMarking;
            component.revision = revision;
            component.references = r.References;

            //Step 3 = Create the dictonary of styles
            var stylesDictionary = new Dictionary<string, Component>()
             {
                {stylesDictionaryComponentName, component},
            };

            //Step 4 Instantiate the "Master" object 
            Master m = new Master("TEST", "{0D947B14-261F-4D54-AEC5-289040C67073}", stylesDictionary);

            //Step 4 - Write thge JSON to the file 
            string json = JsonConvert.SerializeObject(m,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            File.WriteAllText(fileName, json);
            Console.WriteLine(json);
        }






        
       
    }

   
}
