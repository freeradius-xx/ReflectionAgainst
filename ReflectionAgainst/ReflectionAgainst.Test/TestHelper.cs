using System.Collections.Generic;
using System.Linq;
using ReflectionAgainst.Test.Entities;

namespace ReflectionAgainst.Test
{
    public static class TestHelper
    {
        public static List<object> Instances;

        public static void Init(int count)
        {
            Instances = GenerateInstances(count);
        }


        private static List<object> GenerateInstances(int n)
        {
            return Enumerable
                .Range(1, n)
                .Select(i =>
                    i % 2 == 0
                        ? new MyTypeA
                        {
                            Name = "Schabaan",
                            Achievements = new long[] { 1, 2, 3 }
                        } as object
                        : new MyTypeB
                        {
                            FirstName = "Kuduz",
                            Occupation = "Developer"
                        } as object
                ).ToList();
        }
    }
}