using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_2_Number4_2
{
    // ab*cd = 1000 × a × c + 100 × a × d + 100 × b × c + b × d
    class Karatsuba_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            String x = Console.ReadLine();
            Console.WriteLine("Введите второе число");
            String y = Console.ReadLine();
            foreach (var e in Karatsuba(x, y))
            {
                Console.Write(e);
            }
            Console.WriteLine();
        }
        public static List<int> Karatsuba(String x, String y)
        {
            var xSes = AddNumberToList(x);
            var ySes = AddNumberToList(y);
            if (xSes.Count <= 32 || ySes.Count <= 32)
                return Multiplication(x, y);
            else
            {
                LenghtEqualize(xSes, ySes);
                var lenght = Math.Max(xSes.Count, ySes.Count);
                var a = ToStringConvert(xSes).Substring(0, lenght / 2);
                var b = ToStringConvert(xSes).Substring(lenght / 2, lenght / 2);
                var c = ToStringConvert(ySes).Substring(0, lenght / 2);
                var d = ToStringConvert(ySes).Substring(lenght / 2, lenght / 2);
                var ac = Karatsuba(a, c);
                var bd = Karatsuba(b, d);
                var listA = AddNumberToList(a);
                var listB = AddNumberToList(b);
                var listC = AddNumberToList(c);
                var listD = AddNumberToList(d);
                var variable = Karatsuba(ToStringConvert(Summary(listA, listB)), ToStringConvert(Summary(listC, listD)));
                var variable2 = GetDifference(variable, ac);
                var k = TwoNumbEqualizer(variable, ac);
                var ad_plus_bc = GetDifference(variable2, bd);
                var prod1 = Summary(Multiplication(ac.ToString(), TenInPowListCreate(lenght).ToString()), (Multiplication(ad_plus_bc.ToString(), TenInPowListCreate(lenght / 2).ToString())));
                var prod2 = Summary(prod1, bd);
                return prod2;
            }
        }
        public static String ToStringConvert(List<int> br)
        {
            string result = null;
            for (int i = 0; i < br.Count; i++)
            {
                result += Convert.ToString(br[i]);
            }
            return result;
        }
        public static List<int> Summary(List<int> second, List<int> first)
        {
            List<int> result = new List<int>();
            LenghtEqualize(first, second);
            var lenght = Math.Max(first.Count, second.Count);
            for (int i = lenght - 1; i >= 0; i--)
            {
                if (result.Count <= i)
                    result.Add(first[i] + second[i]);
                else
                    result.Insert(i, first[i] + second[i]);
            }
            for (int ix = result.Count - 1; ix > 0; ix--)
            {
                result[ix - 1] += result[ix] / 10;
                result[ix] %= 10;
            }
            return result;
        }
        public static int TwoNumbEqualizer(List<int> first, List<int> second)
        {
            var k = 0;
            LenghtEqualize(first, second);
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] == second[i])
                    continue;
                else if (first[i] > second[i])
                {
                    k = 1;
                    break;
                }
                else if (first[i] < second[i])
                {
                    k = 2;
                    break;
                }
            }
            return k;
        }
        public static List<int> GetDifference(List<int> first, List<int> second)
        {
            var lenght = Math.Max(first.Count, second.Count);
            var k = TwoNumbEqualizer(first, second);
            LenghtEqualize(first, second);
            if (k == 1)
            {
                return SimpleDifference(first, second, lenght);
            }
            else if (k == 2)
            {
                return SimpleDifference(second, first, lenght);
            }
            else
                return new List<int>();
        }
        public static List<int> SimpleDifference(List<int> bigger, List<int> smaller, int lenght)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < lenght - 1; i++)
            {
                bigger[i] -= 1;
                bigger[i + 1] += 10;
            }
            for (var i = lenght - 1; i >= 0; i--)
            {
                if (result.Count <= i)
                    result.Add(bigger[i] - smaller[i]);
                else
                    result[i] = bigger[i] - smaller[i];
            }
            for (int ix = result.Count - 1; ix > 0; ix--)
            {
                result[ix - 1] += result[ix] / 10;
                result[ix] %= 10;
            }
            return result;
        }
        public static void LenghtEqualize(List<int> xSes, List<int> ySes)
        {
            while (xSes.Count > ySes.Count)
            {
                ySes.Insert(0, 0);
            }
            while (ySes.Count > xSes.Count)
            {
                xSes.Insert(0, 0);
            }
            if (Math.Max(ySes.Count, xSes.Count) % 2 != 0)
            {
                xSes.Insert(0, 0);
                ySes.Insert(0, 0);
            }
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
            for (int ix = result.Count - 1; ix > 0; ix--)
            {
                result[ix - 1] += result[ix] / 10;
                result[ix] %= 10;
            }
            return result;
        }
        public static List<int> TenInPowListCreate(int power)
        {
            List<int> ten = new List<int>();
            ten.Add(1);
            while (power > 0)
            {
                ten.Add(0);
                power--;
            }
            return ten;
        }
    }
}
