using System;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(new string[] { " ", ", ", ". ", "- ", "!", "?", "„", "“" }, StringSplitOptions.RemoveEmptyEntries);
          
            
        }

        private static void GetLeastCommonWords(string[] input)
        {
            var wordGroup = input.GroupBy(x => x);
            var maxCount = wordGroup.Min(g => g.Count());
            var mostCommons = wordGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToArray();
            Console.WriteLine(string.Join(" ", mostCommons));
        }

        private static void GetMostCommonWord(string[] input)
        {
            var wordGroup = input.GroupBy(x => x);
            var maxCount = wordGroup.Max(g => g.Count());
            var mostCommons = wordGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToArray();
            Console.WriteLine(string.Join(" ", mostCommons));
        }

        private static void AvarageLenght(string[] input)
        {
            double averageLength = input.Average(w => w.Length);
            Console.WriteLine(averageLength);
        }

        private static void GetLongestWord(string[] input)
        {
            int longestWord = int.MinValue;
            string longestWordLenght = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length > longestWord)
                {
                    longestWord = input[i].Length;
                    longestWordLenght = input[i];
                }
            }

            Console.WriteLine(longestWordLenght);
        }

        private static void GetShortestWord(string[] input)
        {
            int shortestWord = int.MaxValue;
            string shortestWordLenght = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length < shortestWord)
                {
                    shortestWord = input[i].Length;
                    shortestWordLenght = input[i];
                }
            }

            Console.WriteLine(shortestWordLenght);
        }

        private static void GetWordsCount(string[] input)
        {
            int wordsCount = input.Length;
            Console.WriteLine(wordsCount);
        }
    }
}
