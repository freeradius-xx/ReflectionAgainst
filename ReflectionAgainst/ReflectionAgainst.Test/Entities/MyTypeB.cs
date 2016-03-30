using System;

namespace ReflectionAgainst.Test.Entities
{
    public class MyTypeB
    {
        public string FirstName { get; set; }
        public string Occupation { get; set; }
        public DateTime Birth { get; set; }

        public int SomeMehtod()
        {
            return new Random(42).Next(43);
        }
    }
}