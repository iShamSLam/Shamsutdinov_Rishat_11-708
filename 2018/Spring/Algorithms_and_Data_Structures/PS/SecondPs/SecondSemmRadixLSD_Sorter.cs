using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSemmRadix_LSD_Sort
{
    class Reader
    {
        public static IEnumerable<int> Read()
        {
            string[] temp = File.ReadAllText(@"C:\Users\User\Desktop\Проекты\Test.txt").Split(' ');
            int[] tempArr = new int[temp.Length];
            foreach (var e in temp)
            {
                int i = 0;
                tempArr[i] = Convert.ToInt32(e);
                yield return tempArr[i];
                i++;
            }
        }
    }
    public class RadixLSD_Sort
    {
        public int[] Radix(int[] input)
        {
            // очередь в которую помещается изначальный массив
            var numbers = new Queue<int>(input);
            // инициализация ведёр-корзин-кармашек размером 10 для чисел от 0 до 9 соответсвенно
            var buckets = InitializeArray<Queue<int>>(10);
            //инициализация левой и правой веток соответсвенно (границы разрядов 1-10 самые левые разряды)
            int m = 10;
            int n = 1;
            for (int i = numbers.Max().ToString().Length; i > 0; i--)
            {
                while (numbers.Count > 0)
                {
                    //последовательно помещает числа на позицию которая выбирается в соответсвии с формулкой, сначала сравниваются самые
                   // высокие разряды затем далее разряд увеличивается
                    buckets[numbers.Peek() % m / n].Enqueue(numbers.Dequeue());
                }
                foreach (Queue<int> bucket in buckets)
                {
                    while (bucket.Count > 0)
                    {
                        // перезаполнение последовательности 
                        numbers.Enqueue(bucket.Dequeue());
                    }
                }
                // Увеличение рассматриваемых разрядов
                m *= 10;
                n *= 10;
            }
            return numbers.ToArray();
        }
        private static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new RadixLSD_Sort();
            foreach(var e in test.Radix(Reader.Read().ToArray()))
            {
                Console.Write(e);
                Console.Write(" ");
            }
        }
    }
}

