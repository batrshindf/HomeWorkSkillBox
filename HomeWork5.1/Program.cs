using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._1
{
    class Program
    {
        /// <summary>
        /// Создание новой матрицы с параметрами (ширина и высота мтрицы), вводимые пользователем 
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
        /// Проверка Ширины или высоты матрицы (не может быть <= 0)
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
        /// Получения количества строк в матрице (Высота матрицы)
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <returns>Количество строк в матрице (Выоста матрицы)</returns>
        private static int GetMatrixRow(int[,] matrix)
        {
            return matrix.GetLength(0);
        }

        /// <summary>
        /// Получения количества колонок в матрице (Ширина матрицы)
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <returns>Количество колонок в матрице (Ширина матрицы)</returns>
        private static int GetMatrixCol(int[,] matrix)
        {
            return matrix.GetLength(1);
        }

        /// <summary>
        /// Автоматическое заполнение матрицы
        /// </summary>
        /// <param name="matrix">Заполняемая матрица</param>
        /// <param name="random">Псевдо-случайное число</param>
        private static void FillMatrix(int[,] matrix, Random random)
        {
            for (int i = 0; i < GetMatrixRow(matrix); i++)
            {
                for (int j = 0; j < GetMatrixCol(matrix); j++)
                {
                    matrix[i, j] = random.Next(-100, 101);
                }
            }
        }

        /// <summary>
        /// Ручное заполнение матрицы
        /// </summary>
        /// <param name="matrix">Заполняемая матрица</param>
        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < GetMatrixRow(matrix); i++)
            {
                for (int j = 0; j < GetMatrixCol(matrix); j++)
                {
                    Console.WriteLine($"\nВведите данные матрицы с координатами [{i+1},{j+1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        /// <summary>
        /// Вывод матрицы
        /// </summary>
        /// <param name="matrix">Выводимая матрица</param>
        private static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < GetMatrixRow(matrix); i++)
            {
                for (int j = 0; j < GetMatrixCol(matrix); j++)
                {
                    Console.Write($"{matrix[i, j],4} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод исходных мавтриц на экран консоли
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

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        private static void MultiplyingTheMatrixByNumber(int[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("\n\n Умножение матрицы на число!");
            Console.Write("\nВведите число на которое нужно умножить матрицу: ");
            
            var multipliByNumber = int.Parse(Console.ReadLine());
            var matrixC = matrix;

            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(matrix);

            for (int i = 0; i < GetMatrixRow(matrixC); i++)
            {
                for (int j = 0; j < GetMatrixCol(matrixC); j++)
                {
                    matrixC[i, j] *= multipliByNumber;
                }
            }

            Console.WriteLine($"\n\nРезультат умножения исходной матрицы на число {multipliByNumber}: ");
            PrintMatrix(matrixC);

            Console.ReadKey();
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        private static void MatrixAddition(int[,] matrixA, int[,] matrixB)
        {
            var matrix1 = matrixA;
            var matrix2 = matrixB;

            Console.Clear();
            Console.WriteLine("\nСложение матриц!");
            SourceMatrices(matrix1, matrix2);

            if (GetMatrixRow(matrix1) == GetMatrixRow(matrix2) && GetMatrixCol(matrix1) == GetMatrixCol(matrix2))
            {
                for (int i = 0; i < GetMatrixRow(matrix1); i++)
                {
                    for (int j = 0; j < GetMatrixCol(matrix1); j++)
                    {
                        matrix1[i, j] += matrix2[i, j];
                    }
                }

                Console.WriteLine("\nРезультат сложения матриц:");
                PrintMatrix(matrix1);
            }
            else
            {
                Console.WriteLine("\nСложение матриц невозможно. Несоблюдены правила сложения матриц (Разный размер матриц).");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="matrixA">Исходная матрица А (Первая матрица)</param>
        /// <param name="matrixB">Исходная матрица В (Вторая матрица)</param>
        private static void MatrixDifference(int[,] matrixA, int[,] matrixB)
        {
            var matrix1 = matrixA;
            var matrix2 = matrixB;

            Console.Clear();
            Console.WriteLine("\nВычитание матриц!");
            SourceMatrices(matrix1, matrix2);

            if (GetMatrixRow(matrix1) == GetMatrixRow(matrix2) && GetMatrixCol(matrix1) == GetMatrixCol(matrix2))
            {
                for (int i = 0; i < GetMatrixRow(matrix1); i++)
                {
                    for (int j = 0; j < GetMatrixCol(matrix1); j++)
                    {
                        matrix1[i, j] -= matrix2[i, j];
                    }
                }

                Console.WriteLine("\nРезультат вычитания матриц:");
                PrintMatrix(matrix1);
            }
            else
            {
                Console.WriteLine("\nВычитание матриц невозможно. Несоблюдены правила сложения матриц (Разный размер матриц).");
            }

            Console.ReadKey();
        }


        private static void MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            var matrix1 = matrixA;
            var matrix2 = matrixB;

            Console.Clear();
            Console.WriteLine("\n\nПеремножение матриц!");
            
            SourceMatrices(matrix1, matrix2);
            
        }
        static void Main(string[] args)
        {
            Random random = new Random();

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

            Console.ReadKey();
        }

        
    }
}
