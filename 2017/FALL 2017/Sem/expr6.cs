using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            double Distance;
            int x, y, x1, y1, x2, y2,x3,y3;
            Console.WriteLine("Координата х точки ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Координата точки y ");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Координата точки х точки 1 на прямой ");
            x1 = int.Parse(Console. ReadLine());
            Console.WriteLine("Координата точки у точки 1 на прямой ");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Координата точки х2 точки 2 на прямой ");
            x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Координата точки у2 точки 2 на прямой ");
            y2 = int.Parse(Console.ReadLine());

            if (y1 > y2)
            {
                y3 = y1 - y2 / 2; // координата y проекции точки на прямой
            } // int осталась так как единичный отрезок взят за 1 и чисел с плавующей точкой в этой системе не предусмотрено
            if (y1 < y2)
            {
                y3 = y2 - y1 / 2;
            }
            else
            { y2 = y1;
                y3 = y1;
            }
            {
                x3 = x; // так как это проекция ее икс равен иксу проектируемой точки
                Distance =Math.Round(Math.Sqrt(Math.Pow((y3 - y), 2) + Math.Pow((x3 - x1), 2)));
                Console.WriteLine("Расстояние от точки до прямой  = " + Distance);
                Console.ReadLine();
            }

        }
    }
}
