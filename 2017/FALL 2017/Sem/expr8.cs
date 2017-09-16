using System;


namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("y=ax+b");
            double a, b;
            Console.Write("Введите значение коэффициента Х (а)  =  ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение переменной b  = ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты точки (x;y) , через которую нужно провести перпендикуляр к прямой: ");
            double x, y;
            Console.Write("Координата Х = ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Координата У  =");
            y = int.Parse(Console.ReadLine());
            double a2 = Math.Round(-1 / a, 2); // значение  коэффициента прямой, перпендикулярной данной
            double b2 = Math.Round((y - a2 * x), 2); // находим смещение перпендикуляра
            double x1 = Math.Round(((b2 - b) / (a - a2)), 2); // находим точки пересесения х и 2х прямых
            double y1= Math.Round((x * a2 + b2), 2);
            Console.WriteLine("Точка пересечения прямой и  перпендикуляра: ( {0};{1} )", x, y);
            Console.ReadLine();
        }
    }
}