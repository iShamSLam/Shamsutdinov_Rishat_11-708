using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_2_Number_4_1
{
    class Fibbonachi
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите переводимое число");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine("Введенное число в Фиббоначиевой системе");
            Console.WriteLine(FibbonachiSystemInterupt(n));
            Console.WriteLine("Введите число в Фиббоначиевой системе счисления");
            string fibb = Console.ReadLine();
            long result;
            if (fibb == "0")
                result = 0;
            else if (fibb == "1")
                result = 1;
            else
                result = ReverseFibboInterupt(fibb);
            Console.WriteLine("Введенное Фибб СС число в десятичной СС");
            Console.WriteLine(result);

        }
        public static StringBuilder FibbonachiSystemInterupt(long n)
        {
            StringBuilder FibboSystem = new StringBuilder();
            var prev = 1;
            var current = 2;
            var buffer = 0;
            while (current <= n)
            {
                buffer = prev + current;
                prev = current;
                current = buffer;
            }
            while (current > 1)
            {
                if (prev <= n)
                {
                    FibboSystem.Append("1");
                    n -= prev;
                }
                else

                    FibboSystem.Append("0");
                buffer = prev;
                prev = current - prev;
                current = buffer;

            }
            return FibboSystem;
        }
        public static long ReverseFibboInterupt(string fibb)
        {
            long result; 
            long prev = 0; long current = 1; long func;
            result = 0;
            int j = fibb.Length-1;
            while (j >= 0)
            {               
                func = prev + current;
                if (fibb[j] == '1')
                    result +=func;
                j--;
                prev = current;
                current = func;
            }
            return result;
        }
    }
}

