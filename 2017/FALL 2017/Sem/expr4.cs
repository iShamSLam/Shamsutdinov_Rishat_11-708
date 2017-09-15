using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Введите X:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y:");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите N:");
            int n = int.Parse(Console.ReadLine());
            
            int NumberOfRightNumbers;
            NumberOfRightNumbers = ((n - 1) / x) + ((n - 1) / y) - (n - 1) / (x * y);
            Console.WriteLine(NumberOfRightNumbers);
            Console.ReadLine();
        }
    }
}
