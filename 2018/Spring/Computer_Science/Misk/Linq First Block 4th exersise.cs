using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ex__4___1_
{
    public class AbadonedClass
    {
        public static List<string> Sorter(IEnumerable<long> words)
        {
            return words
                .Where(word => word % 2 != 0)
                .Select(word => word.ToString())
                .OrderBy(word => word.Length)
                .ThenBy(word => word)
                .ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            var words = new List<long>();
            for (int i = 0; i < 200; i++)
            {
                words.Add(rand.Next(1, 255));
            }
                foreach (var item in AbadonedClass.Sorter(words))
                Console.WriteLine(item);
        }
    }
}
