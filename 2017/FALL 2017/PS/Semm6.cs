using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semm6
{
    class Program
    { // Найти длину последовательности натуральных чисел, равных в сумме числу n(n<=10^9)
        public static int A, B;
        static void Main(string[] args)
        {             
            int count = 1
                ;
            int sumOfNumbers = 0;
            int max = 0;
            Console.WriteLine("Введите произвольное число n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество чисел в последовательности");
            int quantity = int.Parse(Console.ReadLine());
            if (quantity != 0)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Console.WriteLine("ВВедите " + i + " число");
                    B = int.Parse(Console.ReadLine());


                    if (sumOfNumbers + B == n)
                    {
                        if (max < count)
                        {
                            max = count;
                        }
                        sumOfNumbers = 0;
                        count = 0;
                        break;
                    }
                    else
                    {
                        sumOfNumbers += B;
                        count++;
                    }
                     if (sumOfNumbers + B > n)
                    {
                        max = count - 1;
                        sumOfNumbers = 0;
                        count = 0;
                        break;
                       
                    }
                }
                Console.WriteLine("Максимальное количество чисел в последовательности сумма которой равна n");
                Console.WriteLine(max);
            }
        }
    }
}
