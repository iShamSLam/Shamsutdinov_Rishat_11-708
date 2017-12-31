
using System;

namespace PS_2_Number_2
{
    // Работу выполнил : Шамсутдинов Ришат 11-708
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение точности вычислений(погрешности), точность < 1");           
            Decimal e = Decimal.Parse(Console.ReadLine());
            if (e > 1)
                Console.WriteLine("Введенно неприемлимое значение погрешности");
            else
            {
                Decimal Pi = Gauss_Legendre_Algorithm(e);
                Console.WriteLine("Значение Пи c заданной точностью, вплоть до 25 знака после запятой");
                Console.WriteLine(" Pi={0,1:f26}", Pi);
            }
        }
        public static Decimal Gauss_Legendre_Algorithm(Decimal e)
        {
            Decimal current_Pi = 3, previous_Pi = 0;
            Decimal a_Current = 1, a_Prev;
            Decimal b_Current = 1 / Sqrt(2, 0.0M), b_Prev;
            Decimal t_Current = (Decimal)1 / 4, t_Prev;
            Decimal p_Current = 1, p_Prev;
            while (Math.Abs(a_Current - b_Current) > e)
            {

                previous_Pi = current_Pi;
                a_Prev = a_Current;
                b_Prev = b_Current;
                t_Prev = t_Current;
                p_Prev = p_Current;
                a_Current = (a_Prev + b_Prev) / 2;
                b_Current = Sqrt((a_Prev * b_Prev), 0.0M);
                t_Current = t_Prev - (p_Prev * (a_Prev - a_Current) * (a_Prev - a_Current));
                p_Current = 2 * p_Prev;
                current_Pi = (((a_Current + b_Current) * (a_Current + b_Current)) / (4 * t_Current));
            }
            return current_Pi;
        }
		//---check--- вы бы хоть комментарии ставили, зачем таким образом считаете
        public static decimal Sqrt(decimal x, decimal epsilon = 0.0M)
        {
            decimal current = (decimal)Math.Sqrt((double)x), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }
    }
}

