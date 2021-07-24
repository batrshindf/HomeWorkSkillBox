using System;

namespace HomeWork5._3
{
    internal class Program
    {
        /// <summary>
        ///     Ввод строки пользователем
        /// </summary>
        /// <returns>Введённая строка</returns>
        private static string InputString()
        {
            Console.WriteLine("Введите строку с текстом:");
            return Console.ReadLine();
        }

        /// <summary>
        ///     Нахождение и удаление одинаковых символов в слове
        /// </summary>
        /// <param name="inputString">Строка, введённая пользователем</param>
        /// <returns>Отредактированная строка</returns>
        private static string GetRemovingDuplicateCharacters(string inputString)
        {
            string outputString = "";
            inputString.ToLower();

            for (int i = 0; i < inputString.Length; i++)
                if (i != inputString.Length - 1)
                {
                    if (inputString[i] != inputString[i + 1]) outputString += inputString[i];
                }
                else
                {
                    outputString += inputString[i];
                }

            return outputString;
        }

        private static void Main(string[] args)
        {
            var inputString = InputString();
            var outputString = GetRemovingDuplicateCharacters(inputString);

            Console.WriteLine($"\n{inputString} >>>> {outputString}");

            Console.ReadKey();
        }
    }
}