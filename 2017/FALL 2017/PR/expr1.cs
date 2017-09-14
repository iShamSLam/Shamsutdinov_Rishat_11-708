using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = 5;
            b = 10;
            b = b - a;
            a = a + b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
