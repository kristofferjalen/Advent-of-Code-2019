using System;

namespace Day4A
{
    class Program
    {
        static void Main()
        {
            var count = 0;

            for (var curr = 272091; curr <= 815432; curr++)
            {
                var s = $"{curr}";

                var increasing = true;
                var adjacent = false;
                var i = 0;
                while (i < s.Length - 1)
                {
                    increasing &= s[i + 1] >= s[i];
                    adjacent   |= s[i + 1] == s[i];
                    i++;
                }

                count += increasing && adjacent ? 1 : 0;
            }

            Console.WriteLine(count); // 931
        }
    }
}
