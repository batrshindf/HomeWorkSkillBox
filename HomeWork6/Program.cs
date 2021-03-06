using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace HomeWork6
{
    internal class Program
    {
        private static string outText = "Группа 1: 1";
        private static int countGroup = 1;
        private static readonly string inputPath = "Number.txt";
        private static readonly string outputPath = "OutputGroup.txt";
        private static readonly string compressed = "OutputGroup.zip";

        private static void Main(string[] args)
        {
            var inNumber = GetInputNumber();

            Console.Write("Посчитать только количество групп? (Да/Нет): ");
            var yesNo = Console.ReadLine();
            yesNo.ToLower();

            if (Equals(yesNo, "да"))
            {
                NumberOfGroups(inNumber);
                OutNumberOfGroups(inNumber,true);
            }
            else
            {
                SplitIntoGroup(inNumber);
                WritingToDisk(inNumber);
            }
                
            ArchivingFile();

            Console.ReadKey();
        }

        /// <summary>
        /// Метод нахождения ТОЛЬКО количества групп
        /// </summary>
        /// <param name="inNumber">Число N из файла.</param>
        private static void NumberOfGroups(long inNumber)
        {
            var n = 1;
            while (n < inNumber)
            {
                n *= 2;
                countGroup++;
            }
        }

        /// <summary>
        ///     Архивация полученного файла
        /// </summary>
        private static void ArchivingFile()
        {
            Console.Write("Создать архив данного файла? (Да/Нет): ");
            var yesNo = Console.ReadLine();
            yesNo.ToLower();
            if (Equals(yesNo, "да"))
            {
                using (FileStream ss = new FileStream(outputPath, FileMode.OpenOrCreate))
                {
                    using (FileStream ts = File.Create(compressed)) //поток для записи сжатого файла
                    {
                        using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress)) //Поток архивации
                        {
                            ss.CopyTo(cs); //Копирование основного потока (файла) в другой (архивный)
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine(
                    $"Архивация файла {outputPath} завершина.\nРазмер файла до архивации: {new FileInfo(outputPath).Length} байт;" +
                    $"\nРазмер файла после архивации: {new FileInfo(compressed).Length} байт.");
            }
        }

        /// <summary>
        ///     Запись в файл чисел групп и/или количества групп.
        /// </summary>
        /// <param name="inNumber">Число N</param>
        private static void WritingToDisk(long inNumber)
        {
            File.WriteAllText(outputPath, "");
            Console.Write("Записать группы чисел на диск? (Да/Нет): ");
            var yesNo = Console.ReadLine();
            var a = true;
            yesNo.ToLower();
            if (Equals(yesNo, "да"))
            {
                File.WriteAllText(outputPath, outText);
                a = false;
            }

            OutNumberOfGroups(inNumber, a);
        }

        /// <summary>
        /// Вывод Количества групп.
        /// </summary>
        /// <param name="inNumber">Число N</param>
        /// <param name="a">Условие на добавление строки в пустой файл или файл с данными</param>
        private static void OutNumberOfGroups(long inNumber, bool a)
        {
            string yesNo;
            Console.WriteLine("Записать количество групп на диск? (Да/Нет): ");
            yesNo = Console.ReadLine();
            yesNo.ToLower();
            if (Equals(yesNo, "да"))
            {
                if (a)
                {
                    File.WriteAllText(outputPath, $"Количесвто групп чисел для N = {inNumber} равно {countGroup}.");
                }
                else
                    File.AppendAllText(outputPath,
                        $"\n\n\nКоличесвто групп чисел для N = {inNumber} равно {countGroup}.");
            }
        }

        /// <summary>
        ///     Разбивает числа по группам в диапазоне от 1 до N
        /// </summary>
        /// <param name="inNumber"></param>
        private static void SplitIntoGroup(long inNumber)
        {
            int newLine = 1;

            for (int i = 2; i <= inNumber; i++)
            {
                if (i == newLine * 2)
                {
                    newLine = i;
                    countGroup++;
                    outText += $".\n\nГруппа {countGroup}: {i}";
                }
                else
                {
                    outText += $" {i}";
                }
            }

            outText.Trim();
        }

        /// <summary>
        ///     Чтение числа из файла с проверкой
        /// </summary>
        /// <returns>Число N из файла</returns>
        private static long GetInputNumber()
        {
            long inNumber = 0;

            var inputNumber = File.ReadAllText(inputPath);
            inputNumber = inputNumber.Trim();

            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] == ' ')
                {
                    inputNumber = inputNumber.Substring(0, i);
                    break;
                }
            }

            if (Equals(inputNumber, ""))
            {
                Error();
            }
            else
            {
                if (Regex.IsMatch(inputNumber, @"^[\p{N}]+$") == false)
                {
                    Error();
                }
                else
                {
                    inNumber = long.Parse(inputNumber);

                    if (inNumber < 1 || inNumber > 1_000_000_000)
                    {
                        Error();
                    }
                }
            }

            return inNumber;
        }

        /// <summary>
        ///     Не соблюдение условия или пустой файл
        /// </summary>
        private static void Error()
        {
            outText =
                "Файл пустой или число не удовлетворяет условиям. Введите в файл число в диапозоне: 1 <= N <= 1 000 000 000";
            File.WriteAllText(outputPath, outText);
            Console.WriteLine(outText);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}