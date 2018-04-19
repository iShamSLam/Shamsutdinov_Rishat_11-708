using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new DirectoryInfo(@"C:\Users\User\Desktop\Проекты\test.txt");
            int[] arr = new int[5000];
            Random rand = new Random();
            for(int i = 0; i<arr.Length; i++)
            {
                arr[i] = rand.Next(1, 10650);
                Console.Write(arr[i]);
                if (i + 1 < arr.Length)
                    Console.Write(" ");
            }

            Console.ReadKey();
        }
    }
}
