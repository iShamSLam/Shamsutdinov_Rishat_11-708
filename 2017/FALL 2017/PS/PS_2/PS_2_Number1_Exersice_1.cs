using System;

namespace PS_2_Number1_FirstExersice
{
    // Работу выполнил : Шамсутдинов Ришат 11-708
 
     class Exersice1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение альфа");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение |х| < 1");          
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
                    int k = Cicle(a, x, e);
                    Console.WriteLine("Шаг на котором достигается точность ");
                    Console.WriteLine(k);
                }
            }
            else
                Console.WriteLine("Вы сделали правильный выбор!");
        }
        public static int Cicle(double a, double x, double e)
        {
            double previous;
            double current = 1;
            int k = 0;
            double sum = 1;
            do
            {
                double basic = 1;
                double xSes = 1;
				// ---check--- цикл в цикле? нельзя было оптимальнее решить?
                for (int i = 1; i <= k; i++)
                {
                    if (a - k + 1 != 0)
                    {
                        basic *= (a - k + 1);
                    }
                    xSes *= x / i;
                }
                sum += basic * xSes;
                xSes = 1;
                basic = 1;
                k++;
                previous = current;
                current = sum;
            }
            while (Math.Abs(current - previous) > e);
            return k;
        }
    }
}
