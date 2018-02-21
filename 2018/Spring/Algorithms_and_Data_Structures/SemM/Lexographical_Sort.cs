using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASY_Sort
{
    class LexicographicalSort
    {
        private string word;
        private List<string> sampleList = new List<string>();
        public void Sort()
        {
            Console.WriteLine("Начинается считывание слов, если хотите прекратить вбейте \"end\"");
            do
            {
                if (word != "end")
                {
                    word = Console.ReadLine();
                    sampleList.Add(word);
                }
            }
            while (word!="end");
            foreach(var s in SortByLenght(sampleList))
            {
                Console.WriteLine("....{0}",s);
            }
            Console.ReadLine();
        }

        static IEnumerable<string> SortByLenght(IEnumerable<string> e)
        {
            var sorted = e.OrderBy(s => s).ThenBy(r=>r.Length);
            return sorted;
        }
  
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rema = new LexicographicalSort();
            rema.Sort();
        }
    }
}
