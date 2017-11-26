using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semm3
{
    class Program
    {
        static void Main(string[] args)
        {
            // программу можно было сделать проще, но я вошел в кураж и осознание пришло слишком поздно, а рерайт кода ударит по самолюбию...
            // заранее спасибо за понимание :) 
            // Найти длину самой длинной непрерывной цепочки нулей в двоичном представлении десятичного натурального числа n (n<=10^18)
             long nTest = (long)Math.Pow( 10, 18); // максимальное десятичное натуральное число
            Console.WriteLine("Введите значение десятичного натурального числа");
            // long nTest = int.Parse(Console.ReadLine()); // значение тестовое чтобы вам проще было проверить работоспособность
                                                        // если верите мне, можете сразу раскоментить строку из максимального десятичного натурального числа, она выше 

            //переменная максимального количество подряд идущих нулей 
            int maxSumOfNulls = 0;
            // обнулил созданную строку 
            string binaryNumerationNumber = null;
            // Цикл запускает преобразование десятичного числа в двоичное посредством создания строки с соответсвующими значениями          
            for (long interspirit = nTest; interspirit > 0; interspirit /= 2)
            {
                // если делится без остатка то соответсвенно в двоичный код идет ноль 
                if (interspirit % 2 == 0)
                {
                    binaryNumerationNumber += "0";
                }
                // иначе в в двоичный код уходит единица
                else if (interspirit % 2 == 1)
                {
                    binaryNumerationNumber += "1";
                }
                // условие создано чтобы не делить вечно на ноль 
                else if (interspirit == 1)
                    binaryNumerationNumber += "1";
            }
            // число переводится в строку из нулей и единиц, но ее надо перевернуть если хотите перевернуть уберите слеши со следующей строки
            // так как передо мной стояла задача просто найти наидлиннейшую строку, направление чтения двоичного кода не имела для меня значения
            // string output = new string(binaryNumerationNumber.ToCharArray().Reverse().ToArray());

            // Вывод двоичного кода, добавлен для удобства проверки, можно убрать...
            Console.WriteLine("Число n в двоичной форме");
            Console.WriteLine(binaryNumerationNumber);
            int sumOfNulls = 0;
            decimal d;
            // Цикл через счетчик который подставляет текущее значение d в          
            // а затем выцепляет элемент из строки с номером элемента равным счетчику
            for (d = 0; d < binaryNumerationNumber.Length; d++)
            {

                // условие для нахождение самой длинной строки
                if (Convert.ToString(binaryNumerationNumber[(int)d]) == "0")
                {
                    sumOfNulls = sumOfNulls + 1;

                }

                else
                {
                    if (sumOfNulls > maxSumOfNulls)
                    {
                        maxSumOfNulls = sumOfNulls;

                    }
                    // если значение элемента не равно "0 " то строка обрубает от начала до этого элемента а оба счетчика обнуляются
                    sumOfNulls = 0;
                    binaryNumerationNumber = binaryNumerationNumber.Substring((int)d);
                    d = 0;

                }
            }
            Console.WriteLine("Максимальное значение кол-ва нулей идущих подряд выведено ниже ");
            Console.WriteLine(maxSumOfNulls);
            Console.ReadKey();
        }
    }


}



