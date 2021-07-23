using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._2
{
    class Program
    {
        private static string InputString()
        {
            Console.WriteLine("Введите строку с текстом:");
            return Console.ReadLine();
        }
        private static string[] SeparatorStrings(string inputString)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';', '(', ')', '\t', '\n' };

            string[] workingStrings = inputString.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            return workingStrings;
        }
        private static void OutputWorkingStrings(string[] workingStrings)
        {
            foreach (var word in workingStrings)
            {
                Console.WriteLine($"\n{word}");
            }
        }
        private static string WordMinLength(string inputStrings)
        {
            var workingStrings = SeparatorStrings(inputStrings);
            var min = workingStrings[0].Length;
            var position = 0;

            for (int i = 1; i < workingStrings.Length; i++)
            {
                if (min > workingStrings[i].Length)
                {
                    min = workingStrings[i].Length;
                    position = i;
                }
            }

            return workingStrings[position];
        }
        private static string[] WordMaxLength(string inputString)
        {
            var workingStrings = SeparatorStrings(inputString);
            var max = workingStrings[0].Length;
            string[] returnWords = new string[workingStrings.Length];

            for (int i = 1; i < workingStrings.Length; i++)
            {
                if (max < workingStrings[i].Length)
                {
                    max = workingStrings[i].Length;
                }
            }

            return max;
        }
        static void Main(string[] args)
        {
            var inputString = InputString();

            Console.WriteLine($" Слово с минимальной длинной:  {WordMinLength(inputString)}");


            Console.ReadKey();
        }

        
    }
}
