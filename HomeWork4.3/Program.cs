using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._3
{
    class Program
    {
        /// <summary>
        /// Основной метод
        /// </summary>
        static void Main(string[] args)
        {
            
            Console.Write("Введите высоту матрицы: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("\nВведите ширину матрицы: ");
            int col = int.Parse(Console.ReadLine());

            int[,] matrix = new int[row, col];

            FillMatrix(row, col, matrix);
        }

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
