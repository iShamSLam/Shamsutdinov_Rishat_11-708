using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKaratsuba
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine(Karatsuba(x, y));
        }
        public static double Karatsuba(double x, double y)
        {
            string xs = x.ToString(); string ys = y.ToString();
            if (Math.Min(xs.Length, ys.Length) == 1)
                return x * y;
            if (ys.Length % 2 != 0)
                ys = '0' + ys;
            if (xs.Length % 2 != 0)
                xs = '0' + xs;
            while (xs.Length < ys.Length)
            {
                xs = '0' + xs;
            }
            while (xs.Length > ys.Length)
            {
                ys = '0' + ys;

            }
            int n = Math.Max(xs.Length, ys.Length);
            var xL1 = (xs.Substring(0, n / 2));
            var xR1 = Convert.ToDouble(xs.Substring(n / 2, n / 2));
            var yL1 = (ys.Substring(0, n / 2));
            var yR1 = Convert.ToDouble(ys.Substring(n / 2, n / 2));
            while (xL1[0] == '0')
            {
                if (xL1.Length == 1)
                    break;
                else
                xL1 = xL1.Substring(1);
            }
            while (yL1[0] == '0')
            {
                if (yL1.Length == 1)
                    break;
                else
                yL1 = yL1.Substring(1);
            }
            var xl2 = Convert.ToDouble(xL1); var yl2 = Convert.ToDouble(yL1);
            var prod1_1 = Karatsuba(xl2, yl2);
            var prod2_1 = Karatsuba(xR1, yR1);
            var prod3_1 = Karatsuba(xl2 + xR1, yl2 + yR1);
            return prod1_1 * Math.Pow(10, n) + (prod3_1 - prod1_1 - prod2_1) * Math.Pow(10, n / 2) + prod2_1;

        }
    }
}
