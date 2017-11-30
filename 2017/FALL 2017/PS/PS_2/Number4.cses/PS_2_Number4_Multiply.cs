using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    class Multiply
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            String x = Console.ReadLine();
            Console.WriteLine("Введите второе число");
            String y = Console.ReadLine();
            foreach (var e in Multiplication(x, y))
            {
                Console.Write(e);
            }
            Console.WriteLine();
        }
        public static List<int> Multiplication(String x, String y)
        {
            var xSes = AddNumberToList(x);
            var ySes = AddNumberToList(y);
            var lenght = xSes.Count + ySes.Count;
            List<int> result = new List<int>();
            for (int ix = 0; ix < xSes.Count; ix++)
            {
                for (int jx = 0; jx < ySes.Count; jx++)
                {
                    if (result.Count <= ix + jx)
                        result.Add(xSes[ix] * ySes[jx]);
                    else
                    result[ix + jx] += xSes[ix] * ySes[jx];
                }
            }
            for (int ix = result.Count-1; ix > 0; ix--)
            {
                result[ix - 1] += result[ix] / 10;
                result[ix] %= 10;
            }
            return result;
        }
        public static int[] ConverterToIntArray(String bits)
        {
            char[] bitArray = bits.ToCharArray();
            int[] bitIntArray = new int[bits.Length];
            for (int i = 0; i < bits.Length; i++)
            {
                bitIntArray[i] = bitArray[i] - '0';
            }
            return bitIntArray;
        }
        public static List<int> AddNumberToList(String x)
        {
            var rock = ConverterToIntArray(x);
            List<int> xSes = new List<int>();
            for (var i = 0; i < rock.Length; i++)
            {
                xSes.Add(rock[i]);
            }
            return xSes;
        }
    }
}
