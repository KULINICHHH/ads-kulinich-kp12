using System;
using static System.Math;
using static System.Console;

namespace LAB5
{
    class Program
    {
       

        static int maxValue (int tempMax, int max)
        {
            if (tempMax>max)
            {
                max = tempMax;
            }
            return max;
        }

        static int maxIndexI (int i, int tempI, int tempMax, int max)
        {
            if (tempMax > max)
            {
                i = tempI;
            }
            return i;
        }

        static int maxIndexJ (int j, int tempJ, int tempMax, int max)
        {
            if (tempMax > max)
            {
                j = tempJ;
            }
            return j;
        }


        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int center = (n / 2);
            int j, i, step = 1, max = 0, temp = 0, maxI, maxJ;
            int[,] a = new int[n, n];
            Random rnd = new Random();

            max = a[center, center];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next();
                    Write(a[i, j].ToString() + "\t");

                }
                Console.WriteLine();
            }

            j = center;
            i = center;
            maxI = center;
            maxJ = center;

            int cElem = a[i, j];

            Console.Write(cElem + " ");

            for (int k = 0; k < n; k++)
            {
                for (int h = 0; h < k; h++)
                {
                    j += step;
                    temp = a[i, j];
                    Console.Write(temp + " ");
                    maxI = maxIndexI(maxI, i, temp, max);
                    maxJ = maxIndexJ(maxJ, j, temp, max);
                    max = maxValue(temp, max);
                }

                for (int v = 0; v < k; v++)
                {
                    i += step;
                    temp = a[i, j];
                    Console.Write(temp + " ");
                    maxI = maxIndexI(maxI, i, temp, max);
                    maxJ = maxIndexJ(maxJ, j, temp, max);
                    max = maxValue(temp, max);
                }
                step = -step;
            }

            for (int h = 0; h < n - 1; h++)
            {
                j += step;
                temp = a[i, j];
                Console.Write(temp + " ");
                maxI = maxIndexI(maxI, i, temp, max);
                maxJ = maxIndexJ(maxJ, j, temp, max);
                max = maxValue(temp, max);
            }

            Console.WriteLine("\n Max: [" + maxI + ", " + maxJ + "] " + max);

            if (maxI == maxJ)
            {
                Console.WriteLine("Max elem on main D");
            }
            else if (maxI < maxJ)
            {
                Console.WriteLine("Max elem above main D");
            }
            else
            {
                Console.WriteLine("Max elem under main D");
            }
        }
    }
}
