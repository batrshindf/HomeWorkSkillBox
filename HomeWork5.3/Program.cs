using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = InputString();
            var outputString = GetRemovingDuplicateCharacters(inputString);
            
            Console.WriteLine($"\n{inputString} >>>> {outputString}");

            Console.ReadKey();
        }

        private static string GetRemovingDuplicateCharacters(string inputString)
        {
            string outputString = "";
            inputString.ToLower();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (i != inputString.Length - 1)
                {
                    if (inputString[i] != inputString[i + 1])
                    {
                        outputString += inputString[i];
                    }
                }
                else
                {
                    outputString += inputString[i];
                }
            }

            return outputString;
        }

        private static string InputString()
        {
            Console.WriteLine("Введите строку с текстом:");
            return Console.ReadLine();
        }
    }
}
