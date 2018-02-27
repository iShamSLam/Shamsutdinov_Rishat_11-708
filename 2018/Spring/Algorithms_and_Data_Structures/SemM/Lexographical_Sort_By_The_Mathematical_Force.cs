using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographical_Sort_Mathematical_Version
{

    class Lex_Sort
    {
        private List<string> sampleList = new List<string>();
        private string word;
        private int dimension = 26;
        private void List_Filler()
        {
            Console.WriteLine("Начинается считывание слов, если хотите прекратить вбейте \"end\"");
            do
            {
                word = Console.ReadLine();
                if (word != "end")
                {
                    sampleList.Add(word);
                }
            }
            while (word != "end");
        }
        // Cортировка списка слов по длине слов 
        private void SortbByLenght()
        {
            string buffer;
            for (int i = 0; i < sampleList.Count; i++)
            {
                for (int j = 0; j < sampleList.Count - i - 1; j++)
                    if (sampleList[j].Length > sampleList[j + 1].Length)
                    {
                        buffer = sampleList[j];
                        sampleList[j] = sampleList[j + 1];
                        sampleList[j + 1] = buffer;
                    }
            }
        }
        public string[] LexographicalSort(char firstChar)
        {
            if(sampleList.Count==0)
            {
                throw new Exception("Massive is empty!! are you forget to fill it?! Yeah, of course!");
            }
            List_Filler();
            // Для алгоритма из одинаково длинных слов, избавьтесь от сортировки по длине
            SortbByLenght();
            int difference = 0; int register = 0;
            int maximalIndex = sampleList[sampleList.Count - 1].Length - 1;
            Stack<string>[] clipboard = new Stack<string>[dimension + 1];
            for (int q = 0; q < clipboard.Length; q++)
            {
                clipboard[q] = new Stack<string>();
            }
            List<string> result = sampleList.Cast<string>().ToList();
            while (maximalIndex >= 0)
            {
                for (int q = sampleList.Count - 1; q >= 0; q--)
                {
                    if (result[q].Length < maximalIndex + 1)
                    {
                        maximalIndex = result[q].Length - 1;
                        break;
                    }
                    difference = result[q][maximalIndex] - firstChar;
                    if (difference >= dimension)
                        clipboard[dimension - 1].Push(result[q]);
                    else
                        clipboard[difference].Push(result[q]);
                    register++;
                    if (q == 0) maximalIndex--;
                }
                result.RemoveRange(sampleList.Count - register, register);
                register = 0;
                for (int p = 0; p < clipboard.Length; p++)
                {
                    if (clipboard[p].Count > 0)
                    {
                        result.AddRange(clipboard[p]);
                        clipboard[p].Clear();
                    }
                }
            }
            return result.ToArray();
        }


        class Program
        {
            static void Main(string[] args)
            {
                var test = new Lex_Sort();
                foreach (var e in (test.LexographicalSort('a')))
                {
                    Console.WriteLine(e);
                }
                Console.ReadKey();
            }
        }
    }
}
