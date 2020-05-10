using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contoso.Core.Extensions
{
    public static class ArithmeticExtensions
    {

        public static long Multiply(this IEnumerable<int> nums, int multiplier)
        {
            return nums.Sum() * multiplier;
        }
    }
}
