using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.ArrayQuestion
{
    internal class ClimbingStairs
    {
        public int ClimbStairsOne(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            var f1 = 1;
            var f2 = 2;
            for (var i = 3; i < n + 1; i++)
            {
                var temp = f2;
                f2 = f1 + f2;
                f1 = temp;
            }
            return f2;
        }
    }
}
