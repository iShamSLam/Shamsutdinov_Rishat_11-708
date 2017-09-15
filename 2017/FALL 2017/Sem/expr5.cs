using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int FirstDate, LastDate, LeapYearCount;
            Console.WriteLine("Введите начальную дату");
            FirstDate = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную дату");
            LastDate = int.Parse(Console.ReadLine());
            LeapYearCount = ((LastDate - FirstDate) / 4) + ((LastDate - FirstDate) / 400) - ((LastDate - FirstDate) / 100);
            Console.WriteLine(" Количество високосных лет в данном промежутке =   " + LeapYearCount);
            Console.ReadLine();

                
            
        }
    }
}
