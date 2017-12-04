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
            Decimal x = Decimal.Parse(Console.ReadLine());
            Decimal y = Decimal.Parse(Console.ReadLine());
            Console.WriteLine(Karatsuba (x, y));
            Console.WriteLine(Decimal.MaxValue);
        }
        public static Decimal Karatsuba(Decimal x, Decimal y)
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
            var xR1 = Convert.ToDecimal(xs.Substring(n / 2, n / 2));
            var yL1 = (ys.Substring(0, n / 2));
            var yR1 = Convert.ToDecimal(ys.Substring(n / 2, n / 2));
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
            var xl2 = Convert.ToDecimal(xL1); var yl2 = Convert.ToDecimal(yL1);
            var prod1_1 = Karatsuba(xl2, yl2);
            var prod2_1 = Karatsuba(xR1, yR1);
            var prod3_1 = Karatsuba(xl2 + xR1, yl2 + yR1);
            return prod1_1 * Powerize(n) + (prod3_1 - prod1_1 - prod2_1) * Powerize(n/2) + prod2_1;
        }
        public static Decimal Powerize(int n)
        {
            Decimal result = 1;
            for (var i=0; i<n;i++)
            {
                result *= 10;
            }
            return result;
        }
    }
}
