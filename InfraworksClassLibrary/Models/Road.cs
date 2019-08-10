using InfraworksJSON.Classes._4;
using System;
using System.Collections.Generic;
using System.Linq;
using static InfraworksJSON.StaticClasses.HelperClass;

namespace InfraworksJSON.Models
{
    public class Road
    {
        /*
         * A class that compiles a road cross-section in Infraworks and assigns IDs according 
         * to the rules in the JSON file. 
         * 
         * RULES:
         * 1. First LHS one has no 
         * 
        */


        public int Counter = 0;
        public List<references> References = new List<references>();

        public void AddComponent(string def, double width, bool isLHS)
        {
            //If width = 0 return nothing
            if (width == 0) { return; }

            //Count how many of the components are LHS + RHS 
            int numberOfComponentsLHS = 0;
            int numberOfComponentsRHS = 0;

            for (int i = 0; i < References.Count; i++)
            {                
                if (References[i].paramOverrides.Any(x => x.name == "LeftSideFactor") == true)
                {
                    numberOfComponentsLHS++;
                }
                else { numberOfComponentsRHS++;}
            }

            //If LHS component
            if (isLHS == true)
            {               
                if (numberOfComponentsLHS == 0)  //If first LHS component
                {
                    References.Add(CreateReference(def, width, true));
                }
                else 
                {                 
                    References.Add(CreateReference(def, width, true, Counter));
                    Counter++;
                }
            }
            //If RHS component
            else
            {                
                if (numberOfComponentsRHS == 0) //If first RHS component
                {
                    References.Add(CreateReference(def, width, false));
                }             
                else if (numberOfComponentsRHS == 1) //If second RHS component
                {
                    Counter++;
                    References.Add(CreateReference(def, width, false, Counter));
                    Counter++;
                }
                else //If third RHS component
                {
                    References.Add(CreateReference(def, width, false, Counter));
                    Counter++;
                }
            }
        }

        public void PrintComponentsAndPointIDToConsole()
        {
            foreach (var item in References)
            {
                //Console.Write(item.def);
                //Console.Write("/////");
                if (item.attachment != null) { Console.Write(item.attachment.ex_comp); }
                if (item.paramOverrides != null)
                {
                    foreach (var item2 in item.paramOverrides)
                    {
                        Console.Write($"//////{item2.name},{item2.value}");
                    }
                }
                Console.WriteLine();
            }
        }
                
    }
}
