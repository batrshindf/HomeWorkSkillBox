using System;

namespace HomeWork4._3
{
    internal class Program
    {
        /// <summary>
        ///     Основной метод
        /// </summary>
        private static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Введите высоту первой матрицы: ");
            int row = int.Parse(Console.ReadLine());
            row = CheckInput(row);

            Console.Write("\nВведите ширину первой матрицы: ");
            int col = int.Parse(Console.ReadLine());
            col = CheckInput(col);

            Console.Write("\nВведите высоту второй матрицы: ");
            int row2 = int.Parse(Console.ReadLine());
            row2 = CheckInput(row2);

            Console.Write("\nВведите ширину второй матрицы: ");
            int col2 = int.Parse(Console.ReadLine());
            col2 = CheckInput(col2);

            int[,] matrix = new int[row, col];
            FillMatrix(row, col, matrix, random);

            int[,] matrix2 = new int[row2, col2];
            FillMatrix(row2, col2, matrix2, random);

            MultiplyingTheMatrixByNumber(row, col, matrix);
            MatrixAddition(row, col, row2, col2, matrix, matrix2, random);
            MatrixDifference(row, col, row2, col2, matrix, matrix2, random);
            MatrixMultiplication(row, col, row2, col2, matrix, matrix2);

            Console.ReadKey();
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="row">Ширина первой матрицы</param>
        /// <param name="col">Высота первой матрицы</param>
        /// <param name="row2">Ширина второй матрицы</param>
        /// <param name="col2">Высота второй матрицы</param>
        /// <param name="matrix">Матрица, которую умножают</param>
        /// <param name="matrix2">Матрица, на которую умножают</param>
        private static void MatrixMultiplication(int row, int col, int row2, int col2, int[,] matrix, int[,] matrix2)
        {
            Console.Clear();

            Console.WriteLine("Перемножение матриц!");

            Console.WriteLine("\n\nПервая матрица");
            PrintMatrix(row, col, matrix);

            Console.WriteLine("\n\nВторая матрица:");
            PrintMatrix(row2, col2, matrix2);

            if (matrix.GetLength(0) != matrix2.GetLength(1))
            {
                Console.WriteLine("\n\n\nПеремножение матриц невозможно. Несоблюдены правила перемножения " +
                                  "матриц (кол-во колнок матрицы А неравно кол-ву строк матрицы В).");
                Console.ReadKey();
            }
            else
            {
                var matrix3 = new int[matrix.GetLength(0), matrix2.GetLength(1)];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        matrix3[i, j] = 0;

                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            matrix3[i, j] += matrix[i, k] * matrix2[k, j];
                        }
                    }
                }
                Console.WriteLine("\n\nРезультат:");
                PrintMatrix(matrix.GetLength(0), matrix2.GetLength(1), matrix3);
                Console.ReadKey();
            }
        }


        /// <summary>
        /// Выичтание матриц
        /// </summary>
        /// <param name="row">Выоста матриц</param>
        /// <param name="col">Ширина матриц</param>
        /// <param name="row2">Ширина второй матрицы</param>
        /// <param name="col2">Высота второй матрицы</param>
        /// <param name="matrix">Основная матрица (Первая матрица, из которой вычитают)</param>
        /// <param name="matrix2">Вторая матрица (Которую вычитают)</param>
        /// <param name="random">Псевдо-случайное число</param>
        private static void MatrixDifference(int row, int col, int row2, int col2, int[,] matrix, int[,] matrix2, Random random)
        {
            Console.Clear();

            Console.WriteLine("Вычитание матриц!");

            Console.WriteLine("\n\nПервая матрица");
            PrintMatrix(row, col, matrix);

            Console.WriteLine("\n\nВторая матрица:");
            PrintMatrix(row2, col2, matrix2);

            if (row != row2 || col != col2)
            {
                Console.WriteLine("\n\n\nВычитание матриц невозможно. Несоблюдены правила вычитания " +
                                  "матриц (Разный размер матриц).");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix2[i, j] = matrix[i, j] - matrix2[i, j];
                    }
                }

                Console.WriteLine("\n\nРезультат:");
                PrintMatrix(row, col, matrix2);
                Console.ReadKey();
            }
        }

        /// <summary>
        ///     Сложение матриц
        /// </summary>
        /// <param name="row">Количесвто строк матриц</param>
        /// <param name="col">Количество колонок матриц</param>
        /// <param name="row2">Ширина второй матрицы</param>
        /// <param name="col2">Высота второй матрицы</param>
        /// <param name="matrix">Основная матрица (Первая матрица)</param>
        /// <param name="matrix2">Вторая матрица</param>
        private static void MatrixAddition(int row, int col, int row2, int col2, int[,] matrix, int[,] matrix2, Random random)
        {
            Console.Clear();

            Console.WriteLine("Сложение матриц!");

            Console.WriteLine("\n\nПервая матрица");
            PrintMatrix(row, col, matrix);

            Console.WriteLine("\n\nВторая матрица:");
            PrintMatrix(row2, col2, matrix2);
           
            if (row != row2 || col != col2)
            {
                Console.WriteLine("\n\n\nСложение матриц невозможно. Несоблюдены правила сложения " +
                                  "матриц (Разный размер матриц).");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix2[i, j] += matrix[i, j];
                    }
                }

                Console.WriteLine("\n\nРезультат:");
                PrintMatrix(row, col, matrix2);
                Console.ReadKey();
            }
        }

        /// <summary>
        ///     Умножение матрицы на число
        /// </summary>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество колонок матрицы</param>
        /// <param name="matrix">Матрица на которое нужно умножить число</param>
        private static void MultiplyingTheMatrixByNumber(int row, int col, int[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("\n\n Умножение матрицы на число!");
            Console.Write("\nВведите число на которое нужно умножить матрицу: ");
            var multipliByNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Первая матрица");
            PrintMatrix(row, col, matrix);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] *= multipliByNumber;
                }
            }

            Console.WriteLine($"\n\nРезультат умножения исходной матрицы на число {multipliByNumber}: ");
            PrintMatrix(row, col, matrix);
            Console.ReadKey();
        }

        /// <summary>
        ///     Вывод матрицы
        /// </summary>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество колонок матрицы</param>
        /// <param name="matrix">Выводимая матрица</param>
        private static void PrintMatrix(int row, int col, int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{matrix[i, j], 5} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Проверка ввода на отрицательные и нулевые данные для размерности массива
        /// </summary>
        /// <param name="number">Воод параметра количесва строк или ширрины</param>
        /// <returns>Правильная мерность массива</returns>
        private static int CheckInput(int number)
        {
            while (number <= 0)
            {
                Console.Write("Введите правильный параметр матрицы (долженбыть положительный и не равен 0): ");
                number = int.Parse(Console.ReadLine());
            }

            return number;
        }

        /// <summary>
        ///     Заполнеине матрицы
        /// </summary>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество колонок матрицы</param>
        /// <param name="matrix">Матрица, ввиде двумерного массива</param>
        private static void FillMatrix(int row, int col, int[,] matrix, Random random)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }
    }
}