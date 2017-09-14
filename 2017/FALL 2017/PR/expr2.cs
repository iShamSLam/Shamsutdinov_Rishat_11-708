using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            int c = a;
        
            int b = c / 4 * 10;
            int e = c / 6;
            int d = c / 120;
            int s = b + e + d;
            Console.WriteLine(a);
            Console.WriteLine(s);
        }
    }
}
 