using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farei_Sloboda
{
    class Math_Machine
    {
        void Farei_Printer()
        {
            var steps_number = int.Parse(Console.ReadLine());
            int a, b, c, d, k, buffer1, buffer2;
            if (steps_number <= 1)
            {
                a = 0; b = 1; c = 1; d = 1;
                Console.Write("{0}/{1}  {2}/{3} ", a, b, c, d);
            }
            else
            {
                a = 1; b = 1; c = steps_number - 1; d = steps_number;
                Console.Write("{0}/{1} ", a, b);
                while (c <= steps_number && a > 0)
                {
                    k = (steps_number + b) / d;
                    buffer1 = c; buffer2 = d;
                    c = k * c - a; d = k * d - b;
                    a = buffer1; b = buffer2;
                    Console.Write("    {0}/{1}", a, b);
                }
            }
            Console.WriteLine();
        }
        static void Main()
        {
            var enemy = new Math_Machine();
            enemy.Farei_Printer();
        }

    }
}
