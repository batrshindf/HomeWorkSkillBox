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
        /// Автоматическое заполнение матрицы
        /// </summary>
        /// <param name="matrix">Заполняемая матрица</param>
        /// <param name="random">Псевдо-случайное число</param>
        private static void FillMatrix(int[,] matrix, Random random)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4} ");
                }

                Console.WriteLine();
            }
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

            Console.Clear();
            Console.WriteLine("Исходная матрица А:");
            PrintMatrix(matrixA);
            Console.WriteLine("Исходная матрица В: ");
            PrintMatrix(matrixB);

            Console.ReadKey();
        }
    }
}
