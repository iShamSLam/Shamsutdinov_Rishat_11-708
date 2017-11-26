using System;

namespace PS_2_Number1_Exersice_3
{
    // Работу выполнил : Шамсутдинов Ришат 11-708
    class Exersice3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение |х| < infinity");
            double x = double.Parse(Console.ReadLine());
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
        public static int CicleLn(double e, double x)
        {
            double previous;
            double current = 0;
            int k = 0;
            double sum = 0;
            do
            {
                double basic = Math.Pow(x, k);
                double FactorialDell = 1;

                for (int i = 1; i <= k; i++)
                {
                    FactorialDell *= (double)1 / i;
                }
                sum += basic * FactorialDell;
                FactorialDell = 1;
                k++;
                previous = current;
                current = sum;
            }
            while (Math.Abs(current - previous) > e);
            return k;
        }
    }
}
