using System;

namespace HomeWork4._2
{
    internal class Program
    {
        private const int cellWidth = 4;

        /// <summary>
        ///     Вывод треугольника Паскаля в красивом виде
        /// </summary>
        /// <param name="row">Количество строк в треугольнике</param>
        /// <param name="trianglePascal">Заполненный треугольник Паскаля</param>
        private static void OutputTriangle2(int row, int[,] trianglePascal)
        {
            int col = cellWidth * row;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(col, i + 4);
                    if (trianglePascal[i, j] != 0)
                    {
                        Console.Write($"{trianglePascal[i, j],cellWidth}");
                    }

                    col += cellWidth * 2;
                }

                col = cellWidth * row - cellWidth * (i + 1);

                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Заполнение треугольника Паскаля
        /// </summary>
        /// <param name="row">Количество строк в треугольнике</param>
        /// <param name="trianglePascal">Заполненный треугольник Паскаля</param>
        private static void FillInTheTriangle(int row, int[,] trianglePascal)
        {
            for (int i = 0; i < row; i++)
            {
                trianglePascal[i, 0] = 1;
                trianglePascal[i, i] = 1;
            }

            for (int i = 2; i < row; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    trianglePascal[i, j] = trianglePascal[i - 1, j - 1] + trianglePascal[i - 1, j];
                }
            }
        }

        /// <summary>
        ///     Вывод треугольника Паскаля в простом виде
        /// </summary>
        /// <param name="row">Количество строк в треугольнике</param>
        /// <param name="trianglePascal">
        ///     Заполненный треугольник Паскаля<</param>
        private static void OutputTriangle(int row, int[,] trianglePascal)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (trianglePascal[i, j] != 0)
                    {
                        Console.Write($"{trianglePascal[i, j],cellWidth}");
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Проверка на правильность ввода количества строк треугольника.
        /// </summary>
        /// <param name="row">Количество строк треугольника</param>
        /// <returns>Количество строк треугольника не более 25.</returns>
        private static int CheckInputRow(int row)
        {
            while (row > 25)
            {
                Console.Write("\nУкажите правильно количество строк в треугольнике (не более 25): ");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            return row;
        }

        /// <summary>
        ///     Основной метод
        /// </summary>
        private static void Main(string[] args)
        {
            Console.Write("Введите размер треугольника (количество строк в треугольнике), не более 25 строк: ");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine();

            row = CheckInputRow(row);
            int[,] trianglePascal = new int[row, row];

            FillInTheTriangle(row, trianglePascal);

            //OutputTriangle(row, trianglePascal);  //Для вывода в простом виде надо изменить значение cellWidth с 4 на 8 и закоментировать функцию OutputTriangle2.

            OutputTriangle2(row, trianglePascal); //Для вывода в красивом виде надо изменить значение cellWidth с 8 на 4 и закоментировать функцию OutputTriangle.

            Console.ReadKey();
        }
    }
}