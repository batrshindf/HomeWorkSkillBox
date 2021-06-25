using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._2
{
    class Program
    {
        /// <summary>
        /// Вычисление факториала
        /// </summary>
        /// <param name="number">Числло фаториала которое надо вычислить</param>
        /// <returns>Результат факториала</returns>
        static float GetFactorial(int number)
        {
            float x = 1;
            for (int i = 1; i <= number; i++)
            {
                x *= i;
            }

            return x;
        }

        /// <summary>
        /// Основной метод
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Введите размер треугольника (количество строк в треугольнике): ");
            int triangleSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

          

            Console.ReadKey();
        }
    }
}
