using System;
using System.Collections.Generic;


namespace PS_2_Number_4
{
    // Работу выполнил: Шамсутдинов Ришат 11-708
    class Long_Arithmetic
    {
        private static List<int> NumberReverser(int numb)
        {
            List<int> reverseNumber = new List<int>();
            for (int i = numb; i > 0; i /= 10)
            {
                reverseNumber.Add(i % 10);
            }
            return reverseNumber;
        }
        static int[] InputTaker()
        {
            Console.WriteLine("Введите числа");
            string[] numbersString = Console.ReadLine().Trim(' ').Split(' ');
            int[] numbers = new int[4];
            int i = 0;
            while (i < numbers.Length)
            {
                if (numbersString.Length <= i)
                    numbers[i] = 0;
                else
                {
                    numbers[i] = Convert.ToInt32(numbersString[i]);
                }
                i++;
            }
            return numbers;
        }
        private static List<List<int>> LongNumbsMatching(List<int> bigB, List<int> bigA)
        {
            List<List<int>> matchedNumbers = LongNumbersMatch(bigA, bigB);
            List<List<int>> result = new List<List<int>>();
            result.Add(matchedNumbers[0]);
            result.Add(new List<int>(matchedNumbers[0]));
            int i = 0;
            while (i < matchedNumbers[1].Count)
            {
                if (result[1][i] - matchedNumbers[1][i] >= 0)
                    result[1][i] -= matchedNumbers[1][i];
                else
                {
                    result[1][i] -= -10 + matchedNumbers[1][i];
                    result[1][i + 1] -= 1;
                }
                i++;
            }
            result[0].Reverse();
            result[1].Reverse();
            for (; result[1].Count > 1 && result[1][0] == 0;)
                result[1].RemoveAt(0);
            return result;
        }
        static void Main(string[] args)
        {
            do
            {
                int[] input = InputTaker();
                var a = LongNumbsMatching(PowNumericValueFinder(input[0], input[1]), PowNumericValueFinder(input[2], input[3]));
                Console.Write("Число: ");
                foreach (var e in a[0]) Console.Write(e);
                Console.Write("\nБольше на ");
                foreach (var e in a[1]) Console.Write(e);

                Console.WriteLine("\n#Введите любой символ для завершения");
            } while (Console.ReadLine().Length != 1);
        }

        private static void DigitTransference(List<int> BigNumb, int i)
        {
            if (BigNumb[i] / 10 != 0)
            {
                if (BigNumb.Count <= i + 1)
                {
                    BigNumb.Add(BigNumb[i] / 10);
                }
                else
                {
                    BigNumb[i + 1] += BigNumb[i] / 10;
                }
                BigNumb[i] %= 10;
            }
        }
        private static List<List<int>> LongNumbersMatch(List<int> bigB, List<int> bigA)
        {
            List<List<int>> mathedNumbers = new List<List<int>>();
            if (bigA.Count > bigB.Count)
            {
                mathedNumbers.Add(bigA);
                mathedNumbers.Add(bigB);
            }
            else if (bigA.Count < bigB.Count)
            {
                mathedNumbers.Add(bigB);
                mathedNumbers.Add(bigA);
            }
            else
            {
                bool end = false;
                int i = bigA.Count - 1;
                while ( i >= 0 && !end)
                {
                    if (bigA[i] > bigB[i])
                    {
                        mathedNumbers.Add(bigA);
                        mathedNumbers.Add(bigB);
                        end = true;
                    }
                    else if (bigA[i] < bigB[i])
                    {
                        mathedNumbers.Add(bigB);
                        mathedNumbers.Add(bigA);
                        end = true;
                    }
                    else if (i == 0)
                    {
                        mathedNumbers.Add(bigA);
                        mathedNumbers.Add(bigB);
                    }
                    i--;
                }
            }
            return mathedNumbers;
        }
        //Выдает значение целого положительного числа в степени n 
        private static List<int> PowNumericValueFinder(int numb, int power)
        {
            if (numb < 0) numb *= -1;
            List<int> reverseNumber = NumberReverser(numb);
            List<int> bigNumb = new List<int>(reverseNumber);
            List<int> newBigNumb = new List<int>();
            if (power == 0) { newBigNumb.Add(1); return newBigNumb; }
            int i = 1;
            while ( i < power )
            {
                for (int j = 0; j < reverseNumber.Count; j++)
                {
                    for (int n = 0; n < bigNumb.Count; n++)
                    {
                        if (j + n >= newBigNumb.Count)
                            newBigNumb.Add(bigNumb[n] * reverseNumber[j]);
                        else
                            newBigNumb[j + n] += bigNumb[n] * reverseNumber[j];
                        //Перенос 
                        DigitTransference(newBigNumb, j + n);
                    }
                }
                bigNumb = new List<int>(newBigNumb);
                newBigNumb.Clear();
                i++;
            }
            return bigNumb;
        }
    }
}

