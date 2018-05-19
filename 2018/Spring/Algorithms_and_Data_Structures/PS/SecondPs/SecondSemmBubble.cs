using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSemmBubbleSort
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
    public class BubbleSorter
    {
        public void BubbleSort(int[] arr)
        {
            // Cравнение и перестановка соседних элементов будет проводиться "длина массива" раз
            // Т.е мы N раз пробегаемся по N элементам
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //Проход по массиву
                for (int j = arr.Length - 1; j > i; j--)
                {
                    //Если среди двух соседних элементов первый больше второго, то они меняются местами
                    //Таким образом наибольший элемент будет уходить всё дальше в конец 
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(ref arr[j], ref arr[j - 1]);
                    }
                }
            }
        }
        /// <summary>
        /// Меняет два элемента местами
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var temp = Reader.Read().ToArray();
            var test = new BubbleSorter();
            test.BubbleSort(temp);
            foreach (var em in temp)
            {
                Console.Write(em);
                Console.Write(" ");
            }
        }
    }
}

