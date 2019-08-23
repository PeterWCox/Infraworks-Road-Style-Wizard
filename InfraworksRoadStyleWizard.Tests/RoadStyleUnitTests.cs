using InfraworksClassLibrary;
using InfraworksClassLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InfraworksRoadStyleWizard.Tests
{
    public class RoadStyleUnitTests
    {
        [Fact]
        public void RoadStyleUnitTests()
        {
            {
                Master m = new Master();

                string laneName = @"ComponentDefinition/Lane";
                string shoulderName = @"ComponentDefinition/Shoulder";

                List<ReferenceModel> rm = new List<ReferenceModel>()
            {
                new ReferenceModel(shoulderName, 0, true),
            new ReferenceModel(laneName, 0, true),
            new ReferenceModel(laneName, 3.65, true),
            new ReferenceModel(laneName, 0, true),
            new ReferenceModel(laneName, 0, true),
            new ReferenceModel(laneName, 0, true),
            new ReferenceModel(laneName, 0, true),
            new ReferenceModel(shoulderName, 3, true),

            new ReferenceModel(shoulderName, 0, false),
            new ReferenceModel(laneName, 0, false),
            new ReferenceModel(laneName, 3.65, false),
            new ReferenceModel(laneName, 0, false),
            new ReferenceModel(laneName, 0, false),
            new ReferenceModel(laneName, 0, false),
            new ReferenceModel(laneName, 0, false),
            new ReferenceModel(shoulderName, 3, false)
            };

                component c = new component();
                c.styleType = "Component";
                c.name = "Single Carriageway";
                c.description = "Single 7.3m Carriageway with 3m Verges";
                c.category = "assembly";
                c.showMarking = true;
                c.revision = 1;
                c.AddListComponents(rm);

                m.AddComponent($"Component/Custom/{"Single Carriageway"}", c);

                //Write to JSON file 
                string json = JsonConvert.SerializeObject(m,
                   Formatting.Indented,
                   new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                string expected = File.ReadAllText(@"TestJSONFiles\Test01Single7300CWWith3000Verges.json");
                string actual = json;

                Assert.Equal(expected, actual);

            }
        }

    }
}
