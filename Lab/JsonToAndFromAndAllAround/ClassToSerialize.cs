using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonToAndFromAndAllAround
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Goofballs
    {
        North,
        South,
        East,
        West
    }

    [Serializable]
    public class ClassToSerialize
    {
        public Goofballs myDir { get; set; }

        public int MyId { get; set; }

        public string MyName { get; set; }

        public string[] MyString { get; set; }
    }
}
