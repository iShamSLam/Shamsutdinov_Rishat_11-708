using System;

namespace PS_2_Number1_Exersice_2
{
    // Работу выполнил : Шамсутдинов Ришат 11-708
    class Exersice2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение х принадлежит (-1:1]");
            double x = double.Parse(Console.ReadLine());
            if (Math.Abs(x) >= 1)
                Console.WriteLine("Предупреждение: При заданном иксе последовательность не даст верного ответа");
            Console.WriteLine("Продолжить? Y-да  N - нет");
            char argue = char.Parse(Console.ReadLine());
            if (argue == 'Y')
            {
                Console.WriteLine("Введите точность, точность не больше единицы ");
                double e = double.Parse(Console.ReadLine());
                if (e > 1)
                    Console.WriteLine("Введена неприемлимая точность");
                else
                {
                    int k = CicleLn(e, x);
                    Console.WriteLine("Шаг на котором достигается точность ");
                    Console.WriteLine(k);
                }
            }
            else
                Console.WriteLine("Вы сделали правильный выбор!");
        }
        public static int CicleLn(double e, double x)
        {
            double previous;
            double current = 1;
            int k = 1;
            double sum = 0;
            do
            {
                double basic = -1;
                double xSes = 1;

                for (int i = 1; i <= k; i++)
                {
                    xSes *= x / i;
                }
                sum += Math.Pow(basic, k) * xSes;
                xSes = 1;
                k++;
                previous = current;
                current = sum;
            }
            while (Math.Abs(current - previous) > e);
            return k;
        }
    }
}
