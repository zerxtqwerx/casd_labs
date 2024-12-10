using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var wordLengthsX = GetWordLengths(x);
            var wordLengthsY = GetWordLengths(y);

            for (int i = 0; i < Math.Min(wordLengthsX.Count, wordLengthsY.Count); i++)
            {
                if (wordLengthsX[i] < wordLengthsY[i])
                    return -1;
                if (wordLengthsX[i] > wordLengthsY[i])
                    return 1;
            }

            // Если длины равны до конца одной строки, считается, что более короткая строка меньше
            return wordLengthsX.Count.CompareTo(wordLengthsY.Count);
        }

        private List<int> GetWordLengths(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(word => word.Length)
                       .OrderBy(len => len)
                       .ToList();
        }
    }
}
