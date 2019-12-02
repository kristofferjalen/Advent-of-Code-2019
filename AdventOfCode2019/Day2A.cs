using System;
using System.IO;
using System.Linq;

namespace Day2A
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllText("input/02A-input.txt");

            var z = input.Split(',').Select(int.Parse).ToArray();

            z[1] = 12;
            z[2] = 2;

            var i = 0;
            while (true)
            {
                if (z[i] == 1)
                    z[z[i + 3]] = z[z[i + 1]] + z[z[i + 2]];
                else if (z[i] == 2)
                    z[z[i + 3]] = z[z[i + 1]] * z[z[i + 2]];
                else if (z[i] == 99)
                    break;

                i += 4;
            }
            
            Console.WriteLine(z[0]); // 5290681
        }
    }
}
