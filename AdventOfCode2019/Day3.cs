using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3A
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("input/03-input.txt");

            var paths = input.Select(x => x.Split(',')).ToArray();

            var positions = new List<List<(int, int)>> {
                new List<(int, int)>(),
                new List<(int, int)>()
            };

            var actions = new Dictionary<char, Func<int, int, (int, int)>>
            {
                {'U', (x, y) => (x, y - 1) },
                {'D', (x, y) => (x, y + 1) },
                {'R', (x, y) => (x + 1, y) },
                {'L', (x, y) => (x - 1, y) }
            };

            for (var i = 0; i < 2; i++)
            {
                int x = 0, y = 0;

                foreach (var p in paths[i])
                {
                    for (var j = 1; j <= int.Parse(p.Substring(1)); j++)
                    {
                        positions[i].Add((x, y));
                        (x, y) = actions[p[0]](x, y);
                    }
                }
            }

            var crosses = positions[0].Intersect(positions[1]).Skip(1);

            static int closest((int, int) x) => Math.Abs(x.Item1) + Math.Abs(x.Item2);
            int lowest((int, int) x) => positions[0].IndexOf(x) + positions[1].IndexOf(x);

            Console.WriteLine($"A: {crosses.Min(closest)}"); // 3247
            Console.WriteLine($"B: {crosses.Min(lowest)}");  // 48054
        }
    }
}
