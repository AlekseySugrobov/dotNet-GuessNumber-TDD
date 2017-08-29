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
                Console.WriteLine(@"Another one? [N = no][Another key = yes]");
                answer = Console.ReadLine();
            } while (answer.ToLower() != "n");
            Console.WriteLine("Game is finished.");
            Console.ReadLine();
        }

        private static void playTheGame()
        {
            var guessNumber = new GuessNumber();
            Console.WriteLine("Game is start.");
            do
            {
                Console.WriteLine($"Try {guessNumber.CountTries + 1} from {guessNumber.GetMaxTries()}");
                Console.WriteLine("Enter number:");
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
                ? $"Congratulation! Enterd number is correct! Tries count: {guessNumber.CountTries}"
                : $"You lose. Guessed number is {guessNumber.GetGuessedNumber()}");
        }

        private static void tryingToGuessNumber(GuessNumber guessNumber)
        {
            var enteredNumber = int.Parse(Console.ReadLine());
            if (guessNumber.CheckEnteredNumber(enteredNumber))
            {
                var result = guessNumber.CompareWithGuessedNumber(enteredNumber);
                if (result == CompareResults.Great)
                {
                    Console.WriteLine("Entered number is greater than guessed number");
                }
                else if (result == CompareResults.Less)
                {
                    Console.WriteLine("Entered number is less than guessed nubmer");
                }
            }
            else
            {
                Console.WriteLine(
                    $"Guessed number is from {guessNumber.GetNumberMinValue()} to {guessNumber.GetNumberMaxValue()}");
            }
        }
    }
}
