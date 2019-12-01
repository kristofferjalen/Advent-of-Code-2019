using System;
using System.IO;

namespace Day1B
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input/01A-input.txt");

            var sum = 0;

            foreach (var line in lines)
                sum += Fuel(int.Parse(line));

            Console.WriteLine(sum); // 4928567
        }
        
        static int Fuel(int mass)
        {
            mass = mass / 3 - 2;

            return (mass <= 0) ? 0 : mass + Fuel(mass);
        }
    }
}
