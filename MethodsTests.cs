using Shouldly;
using System;

namespace LearnLinq
{
    public class MethodsTests
    {
        public static Func<string, int> Delegate()
        {
            return new Func<string, int>(int.Parse);
        }

        public static Func<string, int> AnonymousDelegate()
        {
            return delegate (string s)
            {
                return int.Parse(s);
            };
        }

        public static Func<string, int> MethodReference()
        {
            return int.Parse;
        }

        public static Func<string, int> Lambda()
        {
            return s => int.Parse(s);
        }

        public void WaysToCreateDelegates(Func<Func<string, int>> functionGetter)
        {
            var f = functionGetter.Invoke();

            f("123").ShouldBe(123);
        }
    }
}
