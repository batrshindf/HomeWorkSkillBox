using System;
using System.Linq;

namespace HomeWork5._4
{
    internal class Program
    {
        /// <summary>
        ///     Ввод массива чисел через пробел и преобразование из типа string в int
        /// </summary>
        /// <returns>Массив с последоватеьностью чисел</returns>
        private static double[] GetInputNumericalSeries()
        {
            Console.WriteLine("Введите полседовательность чисел через пробел: ");
            string inputConsoleNumericalSeries = Console.ReadLine();
            double[] inputNumericalSeries = inputConsoleNumericalSeries
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();
            return inputNumericalSeries;
        }

        /// <summary>
        ///     Вывод массива на экран консоли
        /// </summary>
        /// <param name="inputNumericalSeries">Входящий массив</param>
        private static void OutputArray(double[] inputNumericalSeries)
        {
            for (int i = 0; i < inputNumericalSeries.Length; i++) Console.Write($"{inputNumericalSeries[i]} ");
        }

        /// <summary>
        ///     Проверка на наличие арифметической прогрессии.
        /// </summary>
        /// <param name="inputNumericalSeries">Массив чисел, который нужно проверить</param>
        /// <returns>True или false</returns>
        private static bool GetCheckArithmeticProgression(double[] inputNumericalSeries)
        {
            var result = true;
            double d = inputNumericalSeries[1] - inputNumericalSeries[0];
            var An = inputNumericalSeries[0] + (inputNumericalSeries.Length - 1) * d;
            if (An == inputNumericalSeries[inputNumericalSeries.Length - 1])
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        ///     Проверка на наличие геометрической прогрессии.
        /// </summary>
        /// <param name="inputNumericalSeries">Массив чисел, который нужно проверить</param>
        /// <returns>True или false</returns>
        private static bool GetCheckGeometricProgression(double[] inputNumericalSeries)
        {
            var result = true;
            double q = inputNumericalSeries[1] / inputNumericalSeries[0];
            var Bn = inputNumericalSeries[0] * Math.Pow(q, inputNumericalSeries.Length - 1);
            Console.WriteLine(inputNumericalSeries.Length);
            if (Bn == inputNumericalSeries[inputNumericalSeries.Length - 1])
                result = true;
            else
                result = false;
            return result;
        }

        /// <summary>
        ///     Проверка на наличие или отсутствие прогрессии
        /// </summary>
        /// <param name="inputNumericalSeries">Массив чисел, который нужно проверить</param>
        /// <returns>Результат в виде текста</returns>
        private static string GetCheckingForProgression(double[] inputNumericalSeries)
        {
            var progression = true;
            var result = "";

            if (progression = GetCheckArithmeticProgression(inputNumericalSeries))
            {
                result += "Данная последовательность чисел является арифметической прогрессией.";
            }
            else
            {
                if (progression = GetCheckGeometricProgression(inputNumericalSeries))
                    result += "Данная последовательность чисел является геометрической прогрессией.";
                else
                    result +=
                        "Данная последовательность чисел не является ни геометрической, ни арифметической прогрессией.";
            }

            return result;
        }

        private static void Main(string[] args)
        {
            var inputNumericalSeries = GetInputNumericalSeries();
            var result = GetCheckingForProgression(inputNumericalSeries);

            Console.Clear();
            OutputArray(inputNumericalSeries);
            Console.WriteLine($"\n{result}");

            Console.ReadKey();
        }
    }
}