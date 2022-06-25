using System;
using System.Collections.Generic;
using static System.Math;

namespace lab3 
{ 
class Program
{

        public static List<int> Sort(List<int> list)
        {
            double l = list.Count;
            double gapF = l / 1.247;
            while (gapF > 1)
            {
                int gap = Convert.ToInt32(Math.Round(gapF));
                for (int i = 0, j = gap; j < l; i++, j++)
                {
                    if (list[i] < list[j])
                    {
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
                gapF = gapF / 1.247;
            }
            return list;
        }



        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(0, 50);
                Console.Write(array[i].ToString() + "\t");
            }

            List<int> pairNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            List<int> leftNumbers = new List<int>();
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] % n == 0)
                {
                    pairNumbers.Add(array[i]);
                }
                else if (array[i] % n == 1)
                {
                    oddNumbers.Add(array[i]);
                }
                else
                {
                    leftNumbers.Add(array[i]);
                }
            }

            pairNumbers = Sort(pairNumbers);
            oddNumbers = Sort(oddNumbers);

            for (int i = 0; i < pairNumbers.Count; i++)
            {
                array[i] = pairNumbers[i];
            }

            for (int i = pairNumbers.Count, j = 0; i < array.Length - leftNumbers.Count; i++, j++)
            {
                array[i] = oddNumbers[j];
            }

            for (int i = array.Length - leftNumbers.Count, j = 0; i < array.Length; i++, j++)
            {
                array[i] = leftNumbers[j];
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }

        }

    }
    }
