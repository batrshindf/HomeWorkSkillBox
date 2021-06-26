using System;

namespace HomeWork4._1
{
    internal class Program
    {
        /// <summary>
        ///     Заполение массива
        /// </summary>
        /// <param name="array">Массив, который нужно заполнить</param>
        /// <param name="random">Массив псевдо-случайных чисел</param>
        /// <returns>Массив, заполненный случайными числами</returns>
        private static int[] GetFilledArray(int[] array, Random random)
        {
            for (int i = 0; i < array.Length; i++) array[i] = random.Next(1000);

            return array;
        }

        /// <summary>
        ///     Вывод таблицы финансов компании за 1 год
        /// </summary>
        /// <param name="income">Доход</param>
        /// <param name="expenses">Расходы</param>
        /// <param name="profit">Прибыль</param>
        private static void OutputOfTheFinancialTable(int[] income, int[] expenses, int[] profit)
        {
            //Вывод шапки тыблицы
            Console.WriteLine("|\tМесяц\t|\tДоходы\t\t|\tРасходы\t\t|\tПрибыль\t\t|");

            //Вывод значений таблицы
            for (int i = 0; i < profit.Length; i++)
                Console.WriteLine($"|\t{i + 1}\t|\t{income[i]}\t\t|\t{expenses[i]}\t\t|\t{profit[i]}\t\t|");
        }

        /// <summary>
        ///     Вывод наихужших месяцев по прибыли.
        /// </summary>
        /// <param name="profit">Прибыль</param>
        private static void BadMonths(int[] profit)
        {
            int[] copyProfit = new int[12];
            int c = 3; //3 наихудших месяца, без одинаковых месяцев
            byte count = 0;

            for (int i = 0; i < copyProfit.Length; i++) copyProfit[i] = profit[i];

            Array.Sort(copyProfit);

            Console.Write("\nНаихудшие месяцы: ");

            for (int i = 0; i < profit.Length; i++)
                if (copyProfit[0] == profit[i])
                {
                    Console.Write($" {i + 1}");
                    count++;
                }

            if (count != profit.Length)
            {
                count = 0;


                for (int i = 1; i < c; i++)
                {
                    if (copyProfit[i] == copyProfit[i - 1])
                    {
                        c++;
                        if (c == copyProfit.Length) break;

                        continue;
                    }

                    for (int j = 0; j < profit.Length; j++)
                        if (copyProfit[i] == profit[j])
                        {
                            Console.Write($" {j + 1}");

                            count++;
                            if (count == profit.Length) break;
                        }
                }
            }
        }

        /// <summary>
        ///     Подсчет и вывод на экран консоли кол-во месяцев с положительной прибылью
        /// </summary>
        /// <param name="profit">Прибыль</param>
        private static void PositiveProfit(int[] profit)
        {
            byte count = 0;

            for (int i = 0; i < profit.Length; i++)
                if (profit[i] > 0)
                    count++;

            Console.WriteLine($"\nКоличество месяцев с положительной прибылью равно {count}.");
        }

        /// <summary>
        ///     Основной метод
        /// </summary>
        private static void Main(string[] args)
        {
            #region Переменные

            Random random = new Random();
            int[] income = new int[12];
            int[] expenses = new int[12];
            int[] profit = new int[12];

            #endregion

            //Заполнение массивов Прибыли и Расходов
            GetFilledArray(income, random);
            GetFilledArray(expenses, random);

            //Находим прибыль
            for (int i = 0; i < profit.Length; i++) profit[i] = income[i] - expenses[i];
             
            OutputOfTheFinancialTable(income, expenses, profit);
            BadMonths(profit);
            PositiveProfit(profit);

            Console.ReadKey();
        }
    }
}