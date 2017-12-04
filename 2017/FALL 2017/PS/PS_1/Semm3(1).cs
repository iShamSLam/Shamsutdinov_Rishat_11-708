using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Этот проект отличается от предыдущего что требует ручной проверки работы кода, но за то соответсвует ваших критериям, наверное.
namespace Semm3_1_
{
    class Program
    {
	// ---check--- этот вариант принимаю
        static void Main(string[] args)
        {   // Найти длину самой длинной непрерывной цепочки нулей в двоичном представлении десятичного натурального числа n (n<=10^18)
            // long nTest = (long)Math.Pow(10, 18); // максимальное десятичное натуральное число
             long nTest = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение десятичного натурального числа");

            // переменная для длины максимальной цепочки нулей 
            short maxOfNullsAtLine = 0;
            // переменная для счетчика нулей идущих подряд
            short counterOfNullsAtLine = 0;

            for (long icounter = nTest; icounter > 0; icounter /= 2)
            {
                // если делится без остатка то соответсвенно в двоичный код идет ноль и можно добавить его в сумму т.к они аналогичны
                if (icounter % 2 == 0)
                    counterOfNullsAtLine += 1;
                // иначе в в двоичный код уходит единица и счетчик обнуляется а максимум нулей принимает значение счетчика если тот меньше него 
                else if (icounter % 2 == 1)
                {
                    if (counterOfNullsAtLine > maxOfNullsAtLine)
                    {
                        maxOfNullsAtLine = counterOfNullsAtLine;
                    }
                    // если значение элемента не равно "0 " то строка обрубает от начала до этого элемента а оба счетчика обнуляются
                    counterOfNullsAtLine = 0;
                }

            }
            Console.WriteLine("Максимальное значение кол-ва нулей идущих подряд выведено ниже ");
            Console.WriteLine(maxOfNullsAtLine);
            Console.ReadKey();
        }
    }
}

