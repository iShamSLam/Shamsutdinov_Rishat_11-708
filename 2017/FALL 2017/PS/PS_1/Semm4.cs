using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semm4
{
    class Program
    {
        public static int A, B;
        static void Main(string[] args)
        {
            //  На вход подаётся последовательность из n целых чисел (по модулю <=10^9). Посчитать число перемен знака в последовательности.
            int count = 0;         
            Console.WriteLine("Введите количество чисел в последовательности");
            int quantity = int.Parse(Console.ReadLine());
            if (quantity != 0)
            {
                Console.WriteLine("Введите нулевое число");
                A = int.Parse(Console.ReadLine());
            }
            else
                Console.WriteLine("Последовательности не существует");
            
             for (int i=1; i<quantity; i++)
            {
                Console.WriteLine("ВВедите "+ i +" число");
                B = int.Parse(Console.ReadLine());
                if (( A<0 && B>0) || (A>0 && B<0))
                {
                    count++;
                }
                A = B;
            }
            Console.WriteLine("Количество перемен знака в последовательности");
            Console.WriteLine(count);
        }
    }
}
