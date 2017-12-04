using System;
using System.Threading;

namespace PS_2_Number_3
{
    // Работу выполнил : Шамсутдинов Ришат 11-708
    class Exersize_3
    {
        static double Function(double x)
        {
            return Math.Cos(Math.Sin(x));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую координату участка определения");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите последнюю координату участка определения");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во равномерно распределеннных точек N");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
                Console.WriteLine("При заданном количестве точек решение невозможно");

            else
            {
                Console.WriteLine("Оценка интеграла методом Монте-Карло равна  " + Monte_Carlo(a, b, n));
                Console.WriteLine("Оценка интеграла методом Левых прямоугольников равна  " + LeftRectangle_Method(n, b, a));
                Console.WriteLine("Оценка интеграла методом Правых прямоугольников равна  " + RightRectangle_Method(n, a, b));
                Console.WriteLine("Оценка итеграла методом Трапеций равна  " + Trapezoid_Method(n, a, b));
                Console.WriteLine("Оценка интеграла Составной формулой Котеса-Симпсона  " + Kotes_Simpson_Method(n, a, b));
                Console.WriteLine("Оценка интеграла формулой Симпсона  " + Simpson_Method(a, b));
            }


        }
        private static double LeftRectangle_Method(int n, double b, double a)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                x = a + (i * h);
                result += Function(x);
            }
            return result * h;
        }
        public static double Monte_Carlo(double a, double b, int n)
        {

            double u, sum = 0;
            double basis = (b - a) / n;
            for (int i = 1; i <= n; i++)
            {
                // Можно добавить Thread.Sleep(1) для того чтобы все значения были рандомными и точность повысилась 
                // Но это очень сильно бьёт по скорости работы
                Random random = new Random();
                u = random.NextDouble() * (b - a) + a;
                // Console.WriteLine(u);
                sum += Function(u);

            }
            return (sum * basis);
        }

        private static double RightRectangle_Method(int n, double a, double b)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 1; i <= n; i++)
            {
                x = a + i * h;
                result += Function(x);
            }
            return result * h;
        }
        private static double Trapezoid_Method(int n, double a, double b)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 1; i < n; i++)
            {
                x = a + i * h;
                result += Function(x);
            }
            result += Function(a) / 2;
            result += Function(b) / 2;
            return result * h;
        }
        private static double Kotes_Simpson_Method(int n, double a, double b)
        {
            double result = 0;
            double h = (b - a) / (2 * n);
            double x = 0;
            result += Function(a);
            result += Function(b);
            result += 4 * Function(XFinderBySimspon(a, 2 * n - 1, h));
            for (int i = 1; i <= n; i++)
            {
                x = XFinderBySimspon(a, 2 * i - 1, h);
                result += 4 * Function(x);
                x = XFinderBySimspon(a, 2 * i, h);
                result += 2 * Function(x);
            }
            return result * h / 3;
        }

        private static double XFinderBySimspon(double a, int number, double h)
        {
            return a + (number) * h;
        }
        private static double Simpson_Method(double a, double b)
        {
            return ((b - a) / 6) * (Function(a) + 4 * Function((a + b) / 2) + Function(b));
        }
    }
}
