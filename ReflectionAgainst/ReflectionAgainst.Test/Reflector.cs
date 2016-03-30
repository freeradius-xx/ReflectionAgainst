using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Fasterflect;
using FastMember;

namespace ReflectionAgainst.Test
{
    public static class Reflector
    {
        public static void WithReflectionTest(int iterationCount)
        {
            RunTest(ReflectionAction, iterationCount);
        }

        public static void WithFastMemberTest(int iterationCount)
        {
            RunTest(FastMemberAction, iterationCount);
        }

        public static void WithFasterflectTest(int iterationCount)
        {
            RunTest(FastReflectAction, iterationCount);
        }


        #region Actions

        private static void RunTest(Action<object> method, int iterationCount)
        {
            var watch = new Stopwatch();
            var results = new List<double>();
            var message = string.Empty;

            while (iterationCount > 0)
            {
                watch.Restart();
                TestHelper.Instances.ForEach(method);
                watch.Stop();

                results.Add(watch.ElapsedMilliseconds);

                message =
                    $"Iteration No: {iterationCount} - Total time: {watch.ElapsedMilliseconds} [ms].{Environment.NewLine}";
                Trace.WriteLine(message);
                Console.WriteLine(message);

                iterationCount--;
            }

            message = $"{Environment.NewLine}Average execution time for: {method.Method}: {results.Average()} [ms].";
            Trace.WriteLine(message);
            Console.WriteLine(message);
        }

        private static void ReflectionAction(object obj)
        {
            var propInfo = obj.GetType().GetProperty("Achievements");
            if (propInfo == null || propInfo.PropertyType != typeof (long[]))
                return;

            var setter = propInfo.GetSetMethod();

            setter?.Invoke(obj, new[] {new long[0]});
        }

        private static void FastMemberAction(object obj)
        {
            var accessor = TypeAccessor.Create(obj.GetType());
            var hasProp = accessor.GetMembers().Any(m => m.Name == "Achievements");
            if (!hasProp)
                return;

            accessor[obj, "Achievements"] = new long[0];
        }

        private static void FastReflectAction(object obj)
        {
            var propInfo = obj.GetType().GetProperty("Achievements");
            if (propInfo == null || propInfo.PropertyType != typeof (long[]))
                return;

            obj.SetPropertyValue("Achievements", new long[0]);
        }

        #endregion
    }
}