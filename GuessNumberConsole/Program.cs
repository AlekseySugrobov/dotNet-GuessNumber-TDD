using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessNumberLibrary;

namespace GuessNumberConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                playTheGame();
                Console.WriteLine(@"Еще раз? [N = нет][Любая другая клавиша = да]");
                answer = Console.ReadLine();
            } while (answer.ToLower() != "n");
            Console.WriteLine("Игра окончена.");
            Console.ReadLine();
        }

        private static void playTheGame()
        {
            var guessNumber = new GuessNumber();
            Console.WriteLine("Число загадано. Игра начата.");
            do
            {
                Console.WriteLine($"Попытка {guessNumber.CountTries + 1} из {guessNumber.GetMaxTries()}");
                Console.WriteLine("Введите число:");
                try
                {
                    tryingToGuessNumber(guessNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!guessNumber.IsGameEnd);
            Console.WriteLine(guessNumber.IsWon
                ? $"Поздравляю! Вы угадали загаданное число! Количество попыток: {guessNumber.CountTries}"
                : $"Вы проиграли. Загаданное число {guessNumber.GetGuessedNumber()} не было угадано!");
        }

        private static void tryingToGuessNumber(GuessNumber guessNumber)
        {
            var enteredNumber = int.Parse(Console.ReadLine());
            if (guessNumber.CheckEnteredNumber(enteredNumber))
            {
                var result = guessNumber.CompareWithGuessedNumber(enteredNumber);
                if (result == CompareResults.Great)
                {
                    Console.WriteLine("Введенное число больше загаданного");
                }
                else if (result == CompareResults.Less)
                {
                    Console.WriteLine("Введенное число меньше загаданного");
                }
            }
            else
            {
                Console.WriteLine(
                    $"Загаданное число находится в диапазоне от {guessNumber.GetNumberMinValue()} до {guessNumber.GetNumberMaxValue()}");
            }
        }
    }
}
