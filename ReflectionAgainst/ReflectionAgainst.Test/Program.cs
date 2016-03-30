using System;

namespace ReflectionAgainst.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestHelper.Init(1000000);

            Reflector.WithFastMemberTest(100);
            Reflector.WithFasterflectTest(100);
            Reflector.WithReflectionTest(100);

            Console.ReadLine();
        }
    }
}