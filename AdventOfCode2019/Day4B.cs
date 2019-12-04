using System;
using System.Linq;

namespace Day4B
{
    class Program
    {
        static void Main()
        {
            var count = 0;

            for (var curr = 272091; curr <= 815432; curr++)
            {
                var s = $"{curr}";

                // Check if increasing
                var increasing = s
                    .Select((c, i) => (i < s.Length - 1 && s[i + 1] >= s[i] || i == s.Length - 1))
                    .All(x => x);
                
                // Check if two adjacent
                var i = 0;
                var twoAdjacent = false;
                while (!twoAdjacent && i < s.Length)
                {
                    var j = i;
                    while (j < s.Length && s[j] == s[i])
                        j++;

                    twoAdjacent = j - i == 2;
                    i = j;
                }

                count += increasing && twoAdjacent ? 1 : 0;
            }

            Console.WriteLine(count); // 609
        }        
    }
}
