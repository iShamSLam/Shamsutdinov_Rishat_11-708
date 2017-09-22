using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_11_Ulearn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Кол-во полных часов ");           
            int hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Кол-во полных минут ");
            int min = int.Parse(Console.ReadLine());
            double minCursorStep = min * 6;
            double angleBetweenCursores = (hours + (min / 60)) * 30 - minCursorStep;
            Console.WriteLine("Разница между минутной и часовой стрелкой равна == " + angleBetweenCursores + "  gradusov " );
            Console.ReadLine();
        }
    }
}
