using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_10___семинар__2_блок___Ошибки
{
    class Program
        
    {
        static int SumX(int starOfCount, int endOfCount, int greatNumber) // количество чисел кратных x на [el, er) 
        {
            starOfCount = (starOfCount % greatNumber == 0 ? starOfCount : starOfCount + greatNumber - starOfCount % greatNumber);
            endOfCount--;
            endOfCount = (endOfCount % greatNumber == 0 ? endOfCount : endOfCount - endOfCount % greatNumber);
            return (starOfCount + endOfCount) * ((endOfCount - starOfCount) / greatNumber + 1) / 2;
        }

        static void Main()
        {
            int result = SumX(1, 1000, 3) + SumX(1, 1000, 5) - SumX(1, 1000, 15);
            Console.WriteLine("Результат : {0}", result);
            Console.ReadLine();
        }
    }
}
