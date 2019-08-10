using InfraworksJSON.Classes._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfraworksClassLibrary.Helpers.HelperClass;

namespace InfraworksClassLibrary.Helpers
{
    public static class CrossSections
    {
        public static Component Test1_SingleCwWith2mVerges()
        {
            string roadName = "TC01-SingleCW";
            int revision = 1;
            string description = "Single 7.3m carriageway with 2m Verges.";
            bool showMarking = true;

            Component c = new Component();

            c.AddComponent(laneName, 3.65, true);
            c.AddComponent(shoulderName, 2, true);
            c.AddComponent(laneName, 3.65, false);
            c.AddComponent(shoulderName, 2, false);

            c.styleType = "Component";
            c.name = roadName;
            c.description = description;
            c.category = "assembly";
            c.showMarking = showMarking;
            c.revision = revision;

            return c;
        }

        public static Component Test2_DualCwWith2mVerges()
        {
            int revision = 1;
            string roadName = "TC01-SingleCW";
            string description = "Single 7.3m carriageway with 2m Verges.";
            bool showMarking = true;

            Component c = new Component();

            c.AddComponent(shoulderName, 1.25, true);
            c.AddComponent(laneName, 3.65, true);
            c.AddComponent(laneName, 3.65, true);
            c.AddComponent(shoulderName, 2, true);
            c.AddComponent(shoulderName, 1.25, false);
            c.AddComponent(laneName, 3.65, false);
            c.AddComponent(laneName, 3.65, false);
            c.AddComponent(shoulderName, 2, false);

            c.styleType = "Component";
            c.name = roadName;
            c.description = description;
            c.category = "assembly";
            c.showMarking = showMarking;
            c.revision = revision;

            return c;
        }

    }
}
