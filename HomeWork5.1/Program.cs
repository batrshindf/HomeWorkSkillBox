using System;

namespace HomeWork5._1
{
    internal class Program
    {
        private static Random random = new Random();
     
        /// <summary>
        ///     Создание новой матрицы с параметрами (ширина и высота мтрицы), вводимые пользователем
        /// </summary>
        /// <returns>Новая матрица</returns>
        private static int[,] GetNewMatrix()
        {
            Console.WriteLine("\nВведите высоту матрицы: ");
            int row = CheckInput(int.Parse(Console.ReadLine()));

            Console.WriteLine("\nВведите ширину матрицы: ");
            int col = CheckInput(int.Parse(Console.ReadLine()));

            int[,] matrix = new int[row, col];

            return matrix;
        }

        /// <summary>
        ///     Проверка Ширины или высоты матрицы (не может быть <= 0)
        /// </summary>
        /// <param name="number">Ширина или высота матрицы</param>
        /// <returns>Высоту или ширину матрицы > 0</returns>
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
        ///     Автоматическое заполнение матрицы
        /// </summary>
        /// <param name="matrix">Заполняемая матрица</param>
        /// <param name="random">Псевдо-случайное число</param>
        private static void FillMatrix(int[,] matrix, Random random)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 11);
                }
            }
        }

        /// <summary>
        ///     Ручное заполнение матрицы
        /// </summary>
        /// <param name="matrix">Заполняемая матрица</param>
        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"\nВведите данные матрицы с координатами [{i + 1},{j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        /// <summary>
        ///     Вывод матрицы
        /// </summary>
        /// <param name="matrix">Выводимая матрица</param>
        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Вывод исходных мавтриц на экран консоли
        /// </summary>
        /// <param name="matrixA">Исхожная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        private static void SourceMatrices(int[,] matrixA, int[,] matrixB)
        {
            Console.WriteLine("Исходная матрица А:");
            PrintMatrix(matrixA);
            Console.WriteLine("\nИсходная матрица В: ");
            PrintMatrix(matrixB);
        }


        private static void Main(string[] args)
        {
            Console.WriteLine("Задайте параметры для матрицы А: ");
            int[,] matrixA = GetNewMatrix();
            Console.WriteLine("\nЗадайте параметры для матрицы В: ");
            int[,] matrixB = GetNewMatrix();

            Console.Clear();
            Console.WriteLine("Хотите заполнить матрицу? (Да(1)/Нет(0)): ");
            int q = int.Parse(Console.ReadLine());
            if (q == 1)
            {
                Console.WriteLine("Введите данные матрицы А (Построчно): ");
                FillMatrix(matrixA);
                Console.WriteLine("\nВведите данные матрицы B (Построчно): ");
                FillMatrix(matrixB);
            }
            else
            {
                FillMatrix(matrixA, random);
                FillMatrix(matrixB, random);
            }

            MultiplyingTheMatrixByNumber(matrixA);
            MultiplyingTheMatrixByNumber(matrixB);
            MatrixAddition(matrixA, matrixB);
            MatrixDifference(matrixA, matrixB);
            MatrixDifference(matrixB, matrixA);
            MatrixMultiplication(matrixA, matrixB);
            MatrixMultiplication(matrixB, matrixA);
        }

        #region Методы вычесления матриц

        /// <summary>
        ///     Умножение матрицы на число
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        private static void MultiplyingTheMatrixByNumber(int[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("\n\n Умножение матрицы на число!");
            Console.Write("\nВведите число на которое нужно умножить матрицу: ");

            var multipliByNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(matrix);

            Console.WriteLine($"\n\nРезультат умножения исходной матрицы на число {multipliByNumber}: ");
            PrintMatrix(GetMultiplyingTheMatrixByNumber(matrix, multipliByNumber));

            Console.ReadKey();
        }

        /// <summary>
        ///     Вычисление умножения матрицы на число
        /// </summary>
        /// <param name="matrix">Матрица которую нужно умножить</param>
        /// <param name="multipliByNumber">Число на которую умножается матрица</param>
        /// <returns>Результат вычесления умножения матрицы на число</returns>
        private static int[,] GetMultiplyingTheMatrixByNumber(int[,] matrix, int multipliByNumber)
        {
            var matrixC = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixC[i, j] = matrix[i, j] * multipliByNumber;
                }
            }

            return matrixC;
        }

        /// <summary>
        ///     Сложение матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        private static void MatrixAddition(int[,] matrixA, int[,] matrixB)
        {
            Console.Clear();
            Console.WriteLine("\nСложение матриц!");
            SourceMatrices(matrixA, matrixB);

            if (matrixA.GetLength(0) == matrixB.GetLength(0) && matrixA.GetLength(1) == matrixB.GetLength(1))
            {
                Console.WriteLine("\nРезультат сложения матриц:");
                PrintMatrix(GetMatrixAddition(matrixA, matrixB));
            }
            else
            {
                Console.WriteLine(
                    "\nСложение матриц невозможно. Несоблюдены правила сложения матриц (Разный размер матриц).");
            }

            Console.ReadKey();
        }

        /// <summary>
        ///     Вычисление Сложения матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        /// <returns>Результат вычисления сложения матриц (Матрица А + Матрица В)</returns>
        private static int[,] GetMatrixAddition(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return matrixC;
        }

        /// <summary>
        ///     Вычитание матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        private static void MatrixDifference(int[,] matrixA, int[,] matrixB)
        {
            Console.Clear();
            Console.WriteLine("\nВычитание матриц!");
            SourceMatrices(matrixA, matrixB);

            if (matrixA.GetLength(0) == matrixB.GetLength(0) && matrixA.GetLength(1) == matrixB.GetLength(1))
            {
                Console.WriteLine("\nРезультат вычитания матриц:");
                PrintMatrix(GetMatrixDifference(matrixA, matrixB));
            }
            else
            {
                Console.WriteLine(
                    "\nВычитание матриц невозможно. Несоблюдены правила сложения матриц (Разный размер матриц).");
            }

            Console.ReadKey();
        }

        /// <summary>
        ///     Вычисления Вычитания матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        /// <returns>Результат вычисления вычитания матриц (Матрица А - Матрица В)</returns>
        private static int[,] GetMatrixDifference(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return matrixC;
        }

        /// <summary>
        ///     Умножение матриц
        /// </summary>
        /// <param name="matrixA">Исходная первая матрица (матрица которую умножают)</param>
        /// <param name="matrixB">Исходная вторая матрица (матрица на которую умножают)</param>
        private static void MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            Console.Clear();
            Console.WriteLine("\n\nПеремножение матриц!");

            SourceMatrices(matrixA, matrixB);

            if (matrixA.GetLength(1) == matrixB.GetLength(0))
            {
                Console.WriteLine("\n\nРезультат:");
                PrintMatrix(GetMatrixMultiplication(matrixA, matrixB));
            }
            else
            {
                Console.WriteLine("\n\n\nПеремножение матриц невозможно. Несоблюдены правила перемножения матриц " +
                                  "(кол-во колнок матрицы А неравно кол-ву строк матрицы В).");
            }

            Console.ReadKey();
        }

        /// <summary>
        ///     Вычисление перемножения матриц
        /// </summary>
        /// <param name="matrixA">Исходная первая матрица (матрица которую умножают)</param>
        /// <param name="matrixB">Исходная вторая матрица (матрица на которую умножают)</param>
        /// <returns>Результат вычислений</returns>
        private static int[,] GetMatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixC[i, j] = 0;

                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        #endregion
    }
}