using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontr_block_one_fouth_exersize
{
    class Program
    {
        /*Даны строковые последовательности A и B,
         * все строки в каждой из них имеют ненулевую длину.
         * Сформировать последовательностей строк вида «a.b»,
         * где а – строка из А, b – либо строка из B с совпадающим количеством букв "q", 
         * что и в строке a, либо строка из одного символа “!”. 
         * Расположить элементы получившейся последовательности в лексикографическом порядке по убыванию. 
         */
        static void Main(string[] args)
        {
            int i = 0;
            var A = new List<string> { "abc", "carmen", "four", "meeeen" };
            var B = new List<string> { "bac", "furmena", "monk" };
            while (A.Count() > B.Count())
                B.Add("!");
            var result = A.Select(word =>
            {
                var temp = B.Select(konc =>
                {
                    if (konc.Length == word.Length)
                        return string.Format("{0}.{1}", word, konc);
                    else return string.Format("{0}." + "!", word);
                });
                if (i <= B.Count)
                {
                    i++;
                    return temp.ElementAt(i - 1);
                }
                else return "";
            }
            )
            .OrderByDescending(z=>z);
            
            foreach (var e in result)
                Console.WriteLine(e);
        }
    }
}
