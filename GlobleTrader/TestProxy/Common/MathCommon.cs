using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public static class MathCommon
    {
        public static double TransStrToDouble(string str)
        {
            double d = 0.00;
            double.TryParse(str, out d);
            return d;
        }

        public static int TransStrToInt(string str)
        {
            int d = 0;
            int.TryParse(str, out d);
            return d;
        }
    }
}
