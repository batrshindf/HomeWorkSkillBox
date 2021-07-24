using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._2
{
    class Program
    {
        /// <summary>
        /// Ввод строки пользователем
        /// </summary>
        /// <returns>Введённая строка</returns>
        private static string InputString()
        {
            Console.WriteLine("Введите строку с текстом:");
            return Console.ReadLine();
        }
        /// <summary>
        /// Разбивка строки на отдельные слова
        /// </summary>
        /// <param name="inputString">Строка, введённая пользователем</param>
        /// <returns>Массив типа string заполненный отдельными словами</returns>
        private static string[] SeparatorStrings(string inputString)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';', '(', ')', '\t', '\n' };

            string[] workingStrings = inputString.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            return workingStrings;
        }
        /// <summary>
        /// Вывод слова или коллекции слов
        /// </summary>
        /// <param name="workingStrings">Массив строк после разбивки</param>
        private static void OutputWorkingStrings(string[] workingStrings)
        {
            foreach (var word in workingStrings)
            {
                Console.WriteLine($"\n{word}");
            }
        }
        /// <summary>
        /// Нахождение слова с минимальной длинной
        /// </summary>
        /// <param name="inputStrings">Строка, введённая пользователем</param>
        /// <returns>Слово с минимальной длинной</returns>
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
        /// <summary>
        /// Находение слова/слов с максимвльной длинной
        /// </summary>
        /// <param name="inputString">Строка, введённая пользователем</param>
        /// <returns>Слово/коллекция слов</returns>
        private static string[] WordMaxLength(string inputString)
        {
            var workingStrings = SeparatorStrings(inputString);
            var max = workingStrings[0].Length;
            string[] returnWords = new string[workingStrings.Length];
            var countReturnWords = 0;

            for (int i = 1; i < workingStrings.Length; i++)
            {
                if (max < workingStrings[i].Length)
                {
                    max = workingStrings[i].Length;
                }
            }

            for (int i = 0; i < workingStrings.Length; i++)
            {
                if (max == workingStrings[i].Length)
                {
                    returnWords[countReturnWords] = workingStrings[i];
                    countReturnWords++;
                }
            }

            return returnWords;
        }
        static void Main(string[] args)
        {
            var inputString = InputString();

            Console.WriteLine($"\nСлово с минимальной длинной:\n\n{WordMinLength(inputString)}");
            Console.WriteLine($"\nСлово/слова с максимальной длинной:");
            OutputWorkingStrings(WordMaxLength(inputString));

            Console.ReadKey();
        }

        
    }
}
