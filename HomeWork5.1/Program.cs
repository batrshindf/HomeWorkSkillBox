using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Введите высоту матрицы: ");
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

        static void Main(string[] args)
        {
            Random random = new Random();

            int[,] matrixA = GetNewMatrix();
            int[,] matrixB = GetNewMatrix();

            Console.WriteLine("Хотите заполнить матрицу? (Да(1)/Нет(0)): ");
            int q = int.Parse(Console.ReadLine());
            if (q == 1)
            {

            }
            else
            {
                FillMatrix(matrixA, random);
                FillMatrix(matrixB, random);
            }
        }

        
    }
}
