using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2
{
    class Program
    {  // По заданному натуральному числу вычислить сумму чисел, меньших его
        // 
        static void Main(string[] args)
        {
            int n; // Заданное число n
            int i; // число для счетчика
            int summOfNumber = 0; // Сумма чисел меньших n
            Console.WriteLine("Введите произвольное натуральное число");
            n = int.Parse(Console.ReadLine());   //    Ввод  Числа
            for (i = (n-1); i >= 1; i--)
                summOfNumber += i;
                Console.WriteLine(summOfNumber);
            Console.ReadKey();
        }
    }
}
