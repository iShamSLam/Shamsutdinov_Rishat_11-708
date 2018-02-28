using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somethings_Ropery_Both_By_Both
{
    class Ropery
    {
        private int apexesMax;
        private int apexesCount;
        private List<int> receiver = new List<int>(apexesMax);
        private bool[] used = new bool[apexesMax];
        private List<int> composition;

        private void RoperyCheck(int vertigo)
        {
            used[vertigo] = true;
            composition.Add(v);
            for (int i = 0; i < receiver.Count(); ++i)
            {
                int couple = composition[vertigo][i];
                if (!used[couple])
                    RoperyCheck(couple);
            }
        }

        public void CompositionFinder()
        {
            for (int i = 0; i < apexesCount; ++i)
            {
                used[i] = false;
            }
            for (int i = 0; i < apexesCount; ++i)
            {
                if (!used[i])
                {
                    composition.Clear();
                    RoperyCheck(i);
                }
                Console.WriteLine(" Compositions:");
                for (int j = 0; j < composition.Count(); ++j)
                {
                    Console.WriteLine(" {0} ", composition[j]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Ropery();
            test.CompositionFinder();
        }
    }
}
