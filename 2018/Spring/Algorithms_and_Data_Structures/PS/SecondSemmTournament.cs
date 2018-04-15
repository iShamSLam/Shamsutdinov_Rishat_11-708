using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Second_PS_Tournament_Sort
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
        public static IEnumerable<int> Initialize()
        {
            var temp = Read()
                .ToList();
            temp.Insert(0, 0);
            return temp;
        }
    }

    class Sort
    {
        public static long Timer = 0;
        private void Initialize(int n, int size, int small, int[] temp, int[] tree)
        {
            int i, j, k;
            for (i = 1; i < n; i++)
            {
                tree[size + i - 1] = temp[i];
                Timer++;
            }
            // Инициализация оставшихся листьев.
            for (i = size + n; i < 2 * size - 1; i++)
            {
                tree[i] = small;
                Timer++;
            }
            // Вычисление веpхних уpовней деpева.
            // Уpовень, непосpедственно находящийся над листьями,
            // обpабатывается отдельно.
            for (j = size; j < 2 * (size - 1); j += 2)
            {
                if (tree[j] >= tree[j + 1])
                    tree[j / 2] = j;
                else
                    tree[j / 2] = j + 1;
                Timer++;
            }
            // Вычисление оставшихся уpовней.
            k = size / 2;
            while (k > 0)
            {
                for (j = k; j < 2 * k - 1; j += 2)
                {
                    if (tree[tree[j]] >= tree[tree[j + 1]])
                        tree[j / 2] = tree[j];
                    else
                        tree[j / 2] = tree[j + 1];                   
                }
                k /= 2;
            }
        }
        public void ShopIterations()
        {
            Console.WriteLine(Timer);
            Timer = 0;
        }

        private void ReadJust(int i, int[] tree)
        {
            int j;
            if (i % 2 == 0)
                tree[i / 2] = i + 1;
            else
                tree[i / 2] = i - 1;
            // Пpодвижение к коpню. 
            i = i / 2;
            while (i > 1)
            {
                if (i % 2 == 0)
                    j = i + 1;
                else
                    j = i - 1;
                if (tree[tree[i]] > tree[tree[j]])
                    tree[i / 2] = tree[i];
                else
                    tree[i / 2] = tree[j];
                i = i / 2;
                Timer++;
            }
        }

        public IEnumerable<int> Tourtament(int[] temp)
        {

            var time = new Stopwatch();
            time.Start();
            int i, k, size, small;
            int n = temp.Length;
            var tree = new int[temp.Length * 4];
            size = 1; small = -3276;

            while (size < n) size *= 2;
            Initialize(n, size, small, temp, tree);
            // Тепеpь после того, как деpево постpоено, повтоpяем опеpацию
            // пеpемещения элемента, пpедставленного коpнем, в следующую
            // позицию с меньшим индексом в массиве x и пеpеупоpядочивание
            // деpева.
            for (k = n - 1; k > 1; k--)
            {
                // i - индекс узла с листом,
                // соответствующим коpню.
                i = tree[1];
                temp[k] = tree[i];
                // Поместить элемент, на ко-
                // тоpый ссылается коpень в
                // позицию k.
                tree[i] = small;
                // Пеpеупоpядочивание деpева
                // в соответствии с новым со-
                // деpжимым tree[i].
                ReadJust(i, tree);
                Timer++;
            }
            temp[1] = tree[tree[1]];
            time.Stop();
            Console.WriteLine(time.ElapsedMilliseconds);
            return temp.Skip(1);

        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var test = new Sort();
            var temp = Reader.Initialize().ToArray();
            test.Tourtament(temp);
            test.ShopIterations();
            Console.WriteLine(temp.Length);             
            Console.ReadKey();
        }

    }
}
