using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UsingAttributes
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyName = "Clayton David Williams";

            SomeClass sc = new SomeClass() {MyAge = 4, MyName = "Juan",};

            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetCustomAttributes<MyAttribute>().Count() > 0
                select t;

            GetAttribute(typeof(SomeClass));

            foreach (var t in types)
            {
                Console.WriteLine(t.Name);

                foreach (var p in t.GetProperties())
                {
                    Console.WriteLine(p.Name);
                    // Console.WriteLine(p.GetValue
                }
            }

            // GetAttribute(typeof);
        }

        private static string MyName { get; set; }

        //[MyAttribute("Say What?")]
        //static Type TestAttribute()
        //{
        //    return null;
        //}

        static void GetAttribute(Type t)
        {
            MyAttribute myAttr = (MyAttribute) Attribute.GetCustomAttribute(t, typeof(MyAttribute));

            if (myAttr == null)
            {
                Console.WriteLine("No attr");
            }
            else
            {
                Console.WriteLine($"name = {myAttr.Name}, level = {myAttr.Level}, reviewed = {myAttr.Reviewed}");
            }
        }
    }

    [My("Clayton Williams", "4", Reviewed = true)]
    public class SomeClass
    {
        public string MyName { get; set; }
        public int MyAge { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute
    {
        private string name;
        private string level;
        private bool reviewed;

        public MyAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }


        public virtual string Name
        {
            get { return name; }
        }

        public virtual string Level
        {
            get { return level; }
        }


        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }
}
