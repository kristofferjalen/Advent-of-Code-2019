using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day12
    {
        public static void Run()
        {
            var input = new[] {
                "<x=-3, y=10, z=-1>",
                "<x=-12, y=-10, z=-5>",
                "<x=-9, y=0, z=10>",
                "<x=7, y=-5, z=-3>"
            };

            var moons = input.Select(x =>
            {
                var coords = x[1..][..^1].Split(',').Select(y => y.Split('=')[1]).Select(int.Parse).ToArray();
                return new[] { coords[0], coords[1], coords[2], 0, 0, 0 };
            }).ToArray();

            // Part A
            for (var i = 0; i < 1000; i++)
            {
                moons = Simulate(moons, 0);
                moons = Simulate(moons, 1);
                moons = Simulate(moons, 2);
            }

            var sum = moons
                        .Select(x => (Math.Abs(x[0]) + Math.Abs(x[1]) + Math.Abs(x[2]))
                                   * (Math.Abs(x[3]) + Math.Abs(x[4]) + Math.Abs(x[5])))
                        .Sum();

            Console.WriteLine($"Part A: {sum}"); // Part A: 10944


            // Part B
            var repeats = new long[3];

            for (var dim = 0; dim < 3; dim++)
            {
                var states = new HashSet<(int, int, int, int, int, int, int, int)>();

                while (true)
                {
                    moons = Simulate(moons, dim);

                    var state = (moons[0][dim], moons[1][dim], moons[2][dim], moons[3][dim],
                                 moons[0][dim + 3], moons[1][dim + 3], moons[2][dim + 3], moons[3][dim + 3]);

                    if (states.Contains(state))
                        break;

                    states.Add(state);
                }

                repeats[dim] = states.Count();
            }

            var lcm = Lcm(repeats);

            Console.WriteLine($"Part B: {lcm}"); // Part B: 484244804958744
        }

        private static int[][] Simulate(int[][] m, int dim)
        {
            m[0][dim + 3] += Gravity(m[1][dim], m[0][dim]);
            m[0][dim + 3] += Gravity(m[2][dim], m[0][dim]);
            m[0][dim + 3] += Gravity(m[3][dim], m[0][dim]);
            m[1][dim + 3] += Gravity(m[0][dim], m[1][dim]);
            m[1][dim + 3] += Gravity(m[2][dim], m[1][dim]);
            m[1][dim + 3] += Gravity(m[3][dim], m[1][dim]);
            m[2][dim + 3] += Gravity(m[0][dim], m[2][dim]);
            m[2][dim + 3] += Gravity(m[1][dim], m[2][dim]);
            m[2][dim + 3] += Gravity(m[3][dim], m[2][dim]);
            m[3][dim + 3] += Gravity(m[0][dim], m[3][dim]);
            m[3][dim + 3] += Gravity(m[1][dim], m[3][dim]);
            m[3][dim + 3] += Gravity(m[2][dim], m[3][dim]);

            m[0][dim] += m[0][dim + 3];
            m[1][dim] += m[1][dim + 3];
            m[2][dim] += m[2][dim + 3];
            m[3][dim] += m[3][dim + 3];

            return m;
        }

        private static int Gravity(int pos1, int pos2) => pos1 > pos2 ? 1 : pos1 < pos2 ? -1 : 0;

        static long Lcm(long[] numbers) => numbers.Aggregate(Lcm);

        static long Lcm(long a, long b) => Math.Abs(a * b) / Gcd(a, b);

        static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
    }
}