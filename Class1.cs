using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLinq
{
    public class ClassTests
    {
        public static int Sum(IEnumerable<int> ints)
        {
            return ints.Sum();
        }
        public static int Sum2(IEnumerable<int> ints)
        {
            var sum = 0;
            foreach (var x in ints)
            {
                sum += x;
            }

            return sum;
        }
        public void CucuTest(Func<IEnumerable<int>, int> sum)
        {
            sum(new[] { 1, 2, 3 }).ShouldBe(6);
        }

        //public void IntTest(int x)
        //{
        //    x.ShouldBe(2);
        //}
    }
}
