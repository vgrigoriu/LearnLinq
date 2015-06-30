using System;
using System.Collections.Generic;
using System.Reflection;
using Fixie;
using System.Linq;

namespace LearnLinq
{
    public class LambdaConvention: Convention
    {
        public LambdaConvention()
        {
            Classes.Where(@class => @class.IsVisible);
            Parameters.Add<FromMarkedFunctions>();
        }
    }

    internal class FromMarkedFunctions : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            if (typeof(Delegate).IsAssignableFrom(method.GetParameters().First().ParameterType))
            {
                var testType = method.DeclaringType.GetTypeInfo();

                var ms = testType.DeclaredMethods;
                foreach (var m in ms)
                {
                    var del = Delegate.CreateDelegate(method.GetParameters().First().ParameterType, m, false);
                    Console.WriteLine(del);
                }

                var methods = from m in testType.DeclaredMethods
                              let del = Delegate.CreateDelegate(method.GetParameters().First().ParameterType, m, false)
                              where del != null
                              select new object[] { del };

                foreach (var del in methods)
                {
                    yield return del;
                }
            }
            else
            {
                yield return new object[] { 2 };
            }
        }
    }
}
