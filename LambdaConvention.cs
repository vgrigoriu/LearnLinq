using System;
using System.Collections.Generic;
using System.Reflection;
using Fixie;
using System.Linq;
using Shouldly;

namespace LearnLinq
{
    public class LambdaConvention: Convention
    {
        public LambdaConvention()
        {
            Classes.Where(@class => @class.IsVisible);
            Parameters.Add<FromMarkedFunctions>();

            HideExceptionDetails
                .For(typeof(ShouldBeTestExtensions).Assembly.GetType("Shouldly.ShouldlyCoreExtensions"))
                .For(typeof(ShouldBeTestExtensions));
        }
    }

    internal class FromMarkedFunctions : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            if (typeof(Delegate).IsAssignableFrom(method.GetParameters().First().ParameterType))
            {
                var testType = method.DeclaringType.GetTypeInfo();

                var methods = from m in testType.DeclaredMethods
                              let del = Delegate.CreateDelegate(method.GetParameters().First().ParameterType, m, false)
                              where del != null
                              select new object[] { del };

                return methods;
            }

            return Enumerable.Empty<object[]>();
        }
    }
}
