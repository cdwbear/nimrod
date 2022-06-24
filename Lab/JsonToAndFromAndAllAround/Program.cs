using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonToAndFromAndAllAround
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassToSerialize cts = new ClassToSerialize
            {
                myDir = Goofballs.East,
                MyId = 42,
                MyName = "Clayton",
                MyString = new []{"one", "two", "three"}
            };

            var jsonStr = JsonConvert.SerializeObject(cts, Formatting.Indented);
            var jsonStr1 = @"{
            ""myDir"": 2,
            ""MyId"": 42,
            ""MyName"": ""Clayton"",
            ""MyString"": [
            ""one"",
            ""two"",
            ""three""
                ]
        }";

            var thisAndThat = JsonConvert.DeserializeObject<ClassToSerialize>(jsonStr1);

            Console.Write(jsonStr);
            Console.ReadKey();
        }
    }
}
