using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = 30; // degress
             double min = 0.5; // degress
            
            Console.WriteLine("Введите координату положения часовой стрелки на часах");
            int HourNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату положения минутной стрелки на часах");
            int MinNumber = int.Parse(Console.ReadLine());


            double diff = HourNumber * hour; // degress of hours
            double diff2 = MinNumber * min; // degress of minute
            if (diff > diff2)
            {
                Console.WriteLine(diff - diff2);
            }
            else
            {
                Console.WriteLine(diff2 - diff);
            }



            
        }
    }
}
