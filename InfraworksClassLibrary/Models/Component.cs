using InfraworksClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfraworksClassLibrary.Helpers.HelperClass;

namespace InfraworksClassLibrary.Models
{

    public class component
    {
        public string styleType { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public bool showMarking { get; set; }
        public int revision { get; set; }

        //A private counter to help assign the correct ex_point to each reference/carriageway component.
        private int Counter = 0;
        public List<references> references = new List<references>();

        /// <summary>
        /// Adds a list of references e.g. road, verge etc to the component object
        /// </summary>
        /// <param name="referenceModel"></param>

        public void AddListComponents(List<ReferenceModel> referenceModel)
        {
            references.Clear();

            foreach (var item in referenceModel)
            {
                AddComponent(item.def, item.width, item.isLHS);
            }
        }

        /// <summary>
        /// Add a reference e.g. road, verge etc to the component object. 
        /// </summary>
        /// <param name="def">The infraworks URL to the reference object e.g."ComponentDefinition/Lane"</param>
        /// <param name="width">The width of the component NOTE: Any components with a width less than 0.1m will be ignored.</param>
        /// <param name="isLHS">True indiciates the reference object will be placed on the LHS of the string centreline</param>
        public void AddComponent(string def, double width, bool isLHS)
        {
            //If width = 0 return nothing
            if (width == 0) { return; }

            //Count how many of the components are LHS + RHS 
            int numberOfComponentsLHS = 0;
            int numberOfComponentsRHS = 0;

            for (int i = 0; i < references.Count; i++)
            {
                if (references[i].paramOverrides.Any(x => x.name == "LeftSideFactor") == true)
                {
                    numberOfComponentsLHS++;
                }
                else { numberOfComponentsRHS++; }
            }

            //If LHS component
            if (isLHS == true)
            {
                if (numberOfComponentsLHS == 0)  //If first LHS component
                {
                    references.Add(CreateReference(def, width, true));
                }
                else
                {
                    references.Add(CreateReference(def, width, true, Counter));
                    Counter++;
                }
            }
            //If RHS component
            else
            {
                if (numberOfComponentsRHS == 0) //If first RHS component
                {
                    references.Add(CreateReference(def, width, false));
                }
                else if (numberOfComponentsRHS == 1) //If second RHS component
                {
                    Counter++;
                    references.Add(CreateReference(def, width, false, Counter));
                    Counter++;
                }
                else //If third RHS component
                {
                    references.Add(CreateReference(def, width, false, Counter));
                    Counter++;
                }
            }
        }

        /// <summary>
        /// Prints off data for each reference component e.g. each road, verge etc - primarily for testing purposes.
        /// </summary>
        public void PrintComponentsAndPointIDToConsole()
        {
            foreach (var item in references)
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
