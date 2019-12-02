using System;
using System.IO;
using System.Linq;

namespace Day2B
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllText("input/02A-input.txt");

            var x = 0;

            var z = new int[input.Length];

            while (x <= 99)
            {
                var y = 0;

                while (y <= 99)
                {
                    z = input.Split(',').Select(int.Parse).ToArray();
                    z[1] = x;
                    z[2] = y++;

                    var i = 0;
                    do
                    {
                        if (z[0] == 19690720)
                        {
                            x = y = 100;
                            break;
                        }
                        else if (z[i] == 1)
                            z[z[i + 3]] = z[z[i + 1]] + z[z[i + 2]];
                        else if (z[i] == 2)
                            z[z[i + 3]] = z[z[i + 1]] * z[z[i + 2]];
                        else
                            break;
                    }
                    while ((i += 4) < z.Length);
                }
                x++;
            }

            Console.WriteLine(100 * z[1] + z[2]); // 5741
        }
    }
}
