﻿using System;

namespace HomeWork4._3
{
    internal class Program
    {
        /// <summary>
        ///     Основной метод
        /// </summary>
        private static void Main(string[] args)
        {
            Console.Write("Введите высоту матрицы: ");
            int row = int.Parse(Console.ReadLine());
            row = CheckInput(row);

            Console.Write("\nВведите ширину матрицы: ");
            int col = int.Parse(Console.ReadLine());
            col = CheckInput(col);

            int[,] matrix = new int[row, col];

            FillMatrix(row, col, matrix);
            PrintMatrix(row, col, matrix);

            MultiplyingTheMatrixByNumber(row, col, matrix);
            PrintMatrix(row, col, matrix);

            Console.ReadKey();
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="row">Количество строк матрицы</param>
        /// <param name="col">Количество колонок матрицы</param>
        /// <param name="matrix">Матрица на которое нужно умножить число</param>
        private static void MultiplyingTheMatrixByNumber(int row, int col, int[,] matrix)
        {
            Console.Write("\nВведите число на которое нужно умножить матрицу: ");
            int multipliByNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] *= multipliByNumber;
                }
            }
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
                    Console.Write($"{matrix[i, j],3} ");
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
        private static void FillMatrix(int row, int col, int[,] matrix)
        {
            Random random = new Random();

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