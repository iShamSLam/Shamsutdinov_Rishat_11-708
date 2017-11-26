using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem5
{
    class Program
    {
        // Найти наименьшее натуральное число q такое, что произведение его цифр равно заданному числу n (n<=10^9)
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число обозначающую диапозон чисел для поиска не превышающее девяти");
            int numberOfNullsAndSteps = int.Parse(Console.ReadLine());           
            int minDellQ = (int)Math.Pow(10, 9);
            Console.WriteLine("Введите произвольное натуральное число n кол-во цифер в котором на единицу меньше числа диапозона");
            Console.WriteLine("Вычисления могут занять время");
            var n = int.Parse(Console.ReadLine());
            // Тестовое значение вводите любое значение вплоть до 10 в 9 степени или одного миллиарда 
            double testNumber = Math.Pow(10, numberOfNullsAndSteps);           
            Console.WriteLine("Наименьшее число q == ");
            Console.WriteLine(MinimalNumberEqivialentToQ(1, Math.Pow(10, numberOfNullsAndSteps), 0, minDellQ, numberOfNullsAndSteps, n));
        }
        // Этот метод принимает диапозон значений вставляет туда значение n, а затем производит поиск числа произведение цифр которого равно заданной n
        public static int MinimalNumberEqivialentToQ(int prodOfNumbersQ, double testNumber, int nextQ, int minDellQ, int numberOfNullsAndSteps,int n)
        {
            for (int i = (int)testNumber; i > 0; i--)
            {
                nextQ = i;
                for (int j = 0; j < numberOfNullsAndSteps; j++)
                {
                    if (nextQ % 10 != 0)
                    {
                        prodOfNumbersQ *= nextQ % 10;
                    }
                    nextQ = nextQ / 10;
                }
                if ((minDellQ > prodOfNumbersQ) && (prodOfNumbersQ == n))
                    minDellQ = i;
                prodOfNumbersQ = 1;
               
            }
            return minDellQ;
        }
    }
}