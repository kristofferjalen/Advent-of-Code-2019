using System;
using System.IO;

namespace Day1A
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input/01A-input.txt");

            var sum = 0;

            foreach (var line in lines)
                sum += int.Parse(line) / 3 - 2;

            Console.WriteLine(sum); // 3287620
        }
    }
}
