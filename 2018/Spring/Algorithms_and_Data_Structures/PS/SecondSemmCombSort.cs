using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSemmCombSort
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
    public class CombSorter
    {
        public  int[] combSort(int[] input)
        {
            // Фиксированное расстояние между элементами - расстояние между двумя концами расчёски
            double gap = input.Length;
            // Флаг для применения пузырьковой сортировки 
            bool swaps = true;
            // Цикл обеспечивающий уменьшение расстояния между гребнями
            while (gap > 1 || swaps)
            {               
                // Уменьшение расстояния на фиксированное "золотое число"
                gap /= 1.247330950103979;
                //Шаг стал равен 1, т.е уменьшать расстояние уже некуда 
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                // Запускается пузырьковая сортировка
                while (i + gap < input.Length)
                {
                    int igap = i + (int)gap;
                    if (input[i] > input[igap])
                    {
                        int swap = input[i];
                        input[i] = input[igap];
                        input[igap] = swap;
                        swaps = true;
                    }
                    i++;
                }
            }
            // Возврат значения
            return input;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var temp = Reader.Read().ToArray();
            var test = new CombSorter();
            foreach (var em in test.combSort(temp))
            {
                Console.Write(em);
                Console.Write(" ");
            }
        }
    }
}
