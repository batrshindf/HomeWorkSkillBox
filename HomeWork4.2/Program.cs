using System;

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
            Console.Write("Введите размер треугольника (количество строк в треугольнике), не более 25 строк: ");
            int triangleSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < triangleSize; i++)
            {
                for (int j = 0; j <= (triangleSize - i); j++) // Создание отступа
                {
                    Console.Write(" ");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write($" {GetFactorial(i) / (GetFactorial(j) * GetFactorial(i - j))}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
