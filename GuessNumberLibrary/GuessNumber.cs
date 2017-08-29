using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberLibrary
{
    public class GuessNumber
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const int MAX_TRIES = 10;
        private int guessedNumber;
        private readonly Random random;
        public bool IsWon { get; set; }
        public int CountTries { get; set; }
        public bool IsGameEnd { get; set; }

        public GuessNumber()
        {
            random = new Random();
            GenerateNumber();
        }

        public int GetGuessedNumber()
        {
            return guessedNumber;
        }

        public bool CheckEnteredNumber(int enteredNumber)
        {
            return enteredNumber >= MIN_VALUE && enteredNumber <= MAX_VALUE;
        }


        public CompareResults CompareWithGuessedNumber(int enteredNumber)
        {
            CountTries++;
            if (CountTries == MAX_TRIES)
                IsGameEnd = true;
            if (enteredNumber == guessedNumber)
            {
                IsWon = true;
                IsGameEnd = true;
                return CompareResults.Equal;
            }
            else if (enteredNumber < guessedNumber)
                return CompareResults.Less;
            else
                return CompareResults.Great;
        }

        public void GenerateNumber()
        {
            guessedNumber = random.Next(MIN_VALUE, MAX_VALUE);
        }

        public int GetMaxTries()
        {
            return MAX_TRIES;
        }

        public int GetNumberMaxValue()
        {
            return MAX_VALUE;
        }

        public int GetNumberMinValue()
        {
            return MIN_VALUE;
        }
    }
}
