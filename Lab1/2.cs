using System;
using static System.Math;
using static System.Console;

namespace ASD2
{
    class Program
    {
        static void Main()
        {
            double n, n1, n2, n3, digit, j;
            Console.WriteLine("Input n: ");
            n = double.Parse(ReadLine());
            for (double i = 1; i <= n; i++)
            {
                n1 = 0;
                j = i;
                while (j > 0)
                {
                    digit = j % 10;
                    j = Floor(j / 10);
                    n1 = n1 * 10;
                    n1 = n1 + digit;
                }
                if (n1 == i)
                {
                    n2 = i * i;
                    n3 = 0;
                    while (n2 > 0)
                    {
                        digit = n2 % 10;
                        n2 = Floor(n2 / 10);
                        n3 = n3 * 10;
                        n3 = n3 + digit;
                    }
                    n2 = i * i;
                    if (n2 == n3)
                    {
                        Console.Write(i + " ");
                    }
;                }
            }
        }
    }
}
