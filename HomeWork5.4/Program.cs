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
            Console.WriteLine("Введите полседовательность чисел через пробел (не менее 3-х и без букв): ");
            string inputConsoleNumericalSeries = Console.ReadLine();
            inputConsoleNumericalSeries = GetCheckInputNum(inputConsoleNumericalSeries);
            double[] inputNumericalSeries = inputConsoleNumericalSeries
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();
            inputNumericalSeries = GetCheckInputLength(inputNumericalSeries);

            return inputNumericalSeries;
        }

        /// <summary>
        /// Проверка ввода на наличие других символов кроме чисел
        /// </summary>
        /// <param name="inpuinputConsoleNumericalSeriestNumSer">Вводимая последовательность чисел</param>
        /// <returns>Проверенная последовательность чисел</returns>
        private static string GetCheckInputNum(string inpuinputConsoleNumericalSeriestNumSer)
        {
            var inputString = inpuinputConsoleNumericalSeriestNumSer;
            var b = false;

            while (b == false)
            {
                if (inputString.Length == 0)
                {
                    Console.WriteLine("Введите полседовательность чисел через пробел (не менее 3-х и без букв): ");
                    inputString = Console.ReadLine();
                }
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (inputString[i] == ' ') continue;
                    b = Char.IsDigit(inputString, i);
                    if (b == false)
                    {
                        Console.WriteLine("Введите полседовательность чисел через пробел (не менее 3-х и без букв): ");
                        inputString = Console.ReadLine();
                    }
                }
            }

            return inputString;
        }


        /// <summary>
        /// Проверка ввода количества чисел для проверки на прогрессию (не менее 3-х чисел)
        /// </summary>
        /// <param name="inputNumSer">Вводимая последовательность чисел</param>
        /// <returns>Проверенная последовательность чисел, от 3-х штук</returns>
        private static double[] GetCheckInputLength(double[] inputNumSer)
        {
            while (inputNumSer.Length <= 2)
            {
                Console.WriteLine("Введите полседовательность чисел через пробел (не менее 3-х и без букв): ");
                string inputConsoleNumericalSeries = Console.ReadLine();
                inputConsoleNumericalSeries = GetCheckInputNum(inputConsoleNumericalSeries);
                inputNumSer = inputConsoleNumericalSeries
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x))
                    .ToArray();
            }
            
            return inputNumSer;
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
        private static int GetCheckArithmeticProgression(double[] inputNumericalSeries)
        {
            int result;
            double d = inputNumericalSeries[1] - inputNumericalSeries[0];
            var An = inputNumericalSeries[0] + (inputNumericalSeries.Length - 1) * d;
            if (An == inputNumericalSeries[inputNumericalSeries.Length - 1])
                result = 1;
            else
                result = 2;

            return result;
        }

        /// <summary>
        ///     Проверка на наличие геометрической прогрессии.
        /// </summary>
        /// <param name="inputNumericalSeries">Массив чисел, который нужно проверить</param>
        /// <returns>True или false</returns>
        private static int GetCheckGeometricProgression(double[] inputNumericalSeries)
        {
            int result;
            double q = inputNumericalSeries[1] / inputNumericalSeries[0];
            var Bn = inputNumericalSeries[0] * Math.Pow(q, inputNumericalSeries.Length - 1);
            Console.WriteLine(inputNumericalSeries.Length);
            if (Bn == inputNumericalSeries[inputNumericalSeries.Length - 1])
                result = 1;
            else
                result = 2;
            return result;
        }

        /// <summary>
        ///     Проверка на наличие или отсутствие прогрессии
        /// </summary>
        /// <param name="inputNumericalSeries">Массив чисел, который нужно проверить</param>
        /// <returns>Результат в виде текста</returns>
        private static string GetCheckingForProgression(double[] inputNumericalSeries)
        {
            var result = "";

            if (1 == GetCheckArithmeticProgression(inputNumericalSeries))
            {
                result += "Данная последовательность чисел является арифметической прогрессией.";
            }
            else
            {
                if (1 == GetCheckGeometricProgression(inputNumericalSeries))
                {
                    if (inputNumericalSeries[inputNumericalSeries.Length - 1] == inputNumericalSeries[inputNumericalSeries.Length - 2])
                        result += "Данная последовательность чисел не является ни геометрической, ни арифметической прогрессией.";
                    else
                        result += "Данная последовательность чисел является геометрической прогрессией.";
                }
                else
                {
                    result += "Данная последовательность чисел не является ни геометрической, ни арифметической прогрессией.";
                }
                    
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