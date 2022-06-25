using System;
using static System.Math;
using static System.Console;

namespace ASD
{
    class Program
    {
        static void Main()
        {
            double x, y, z, a, b, c, d;
            Console.WriteLine("Input x: ");
            x = double.Parse(ReadLine());
            Console.WriteLine("Input y: ");
            y = double.Parse(ReadLine());
            Console.WriteLine("Input z: ");
            z = double.Parse(ReadLine());
            c = Pow(x, z) - Sqrt(Pow(x, 2) - y * Pow(z, 3));
            d = Pow(x, 2) - y * Pow(z, 3);
            if (c == 0  || d < 0)
            {
                Console.WriteLine("misstake");
            }
            else
            {
                a = (x + y - z) / c;
                if (a == 0)
                {
                    Console.WriteLine("a = " + a + "b can not be founded");
                }
                else
                {
                    b = Cos((x * y + Pow(y, 2)) / a * a);
                    Console.WriteLine("a = " + a + " b = " + b);
                }
            }
        }
    }
}
