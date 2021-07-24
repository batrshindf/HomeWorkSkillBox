using System;

namespace HomeWork5._5
{
    internal class Program
    {
        /// <summary>
        ///     Проверка ввода чисел (число >= 0)
        /// </summary>
        /// <param name="number">Число введёное пользователем</param>
        /// <returns>Правильное число</returns>
        private static UInt64 CheckInput(UInt64 number)
        {
            while (number < 0)
            {
                Console.WriteLine("Введено не верное число. Число должно быть больше 0: ");
                number = UInt64.Parse(Console.ReadLine());
            }

            return number;
        }

        /// <summary>
        ///     Вычисление функции Аккермана
        /// </summary>
        /// <param name="m">Первое число, вводимое пользователем</param>
        /// <param name="n">Второе число, вводимое пользователем</param>
        /// <returns>Результат вычислений</returns>
        private static UInt64 AckermanFunction(UInt64 m, UInt64 n)
        {
            if (m == 0)
            {
                return n + 1;
            }

            if (m > 0 && n == 0)
            {
                return AckermanFunction(m - 1, 1);
            }

            return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Введите число m: ");
            var m = UInt64.Parse(Console.ReadLine());
            m = CheckInput(m);

            Console.WriteLine("Введите число n: ");
            var n = UInt64.Parse(Console.ReadLine());
            n = CheckInput(n);
            
            Console.WriteLine($"\nРезультат вычисления функции Аккермана равен: {AckermanFunction(m, n)}");
            
            Console.ReadKey();
        }
    }
}