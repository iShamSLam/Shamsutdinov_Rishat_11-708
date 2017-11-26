using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9ns_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            int bMin = 0;
            Console.WriteLine("Введите начальное  число последовательности ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число с на которое делит последовательность без остатка");
            Console.WriteLine("Это число должно быть не больше 10000");
            int c = int.Parse(Console.ReadLine());
            if (c > 10000)
                Console.WriteLine("Введенное число не соответсвует параметру");
            else
            {
                string lineOfNumbers = null;
                while (a < 10000)
                {
                    lineOfNumbers += Convert.ToString(a);
                    if (Convert.ToDouble(lineOfNumbers) % c == 0)
                    {
                        bMin = a;
                        break;
                    }
                    a++;
                }
                if (bMin == 0)
                    Console.WriteLine("@ По заданным параметрам не существует такого числа " +
                        "Которое бы делилось на заданное число с");
                else
                {
                    Console.WriteLine("Минимальное значение b");
                    Console.WriteLine(bMin);
                }
            }
        }
    }
}

