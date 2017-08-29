using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessNumberLibrary;

namespace GuessNumberTests
{
    [TestClass]
    public class GuessNumberTests
    {
        private readonly GuessNumber _guessNumber;

        public GuessNumberTests()
        {
            _guessNumber = new GuessNumber();
        }

        [TestMethod]
        public void IsNumberExists()
        {
            Assert.AreNotEqual(null, _guessNumber.GetGuessedNumber());
        }

        [TestMethod]
        public void IsEnteredNumberAreEqualGuessedNumber()
        {
            var enteredNumber = _guessNumber.GetGuessedNumber();
            Assert.AreEqual(CompareResults.Equal, _guessNumber.CompareWithGuessedNumber(enteredNumber));
        }

        [TestMethod]
        public void IsEnteredNumberAreLessThanGuessedNumber()
        {
            var enteredNumber = _guessNumber.GetGuessedNumber() - 100;
            Assert.AreEqual(CompareResults.Less, _guessNumber.CompareWithGuessedNumber(enteredNumber));
        }

        [TestMethod]
        public void IsEnteredNumberAreGreaterThanGuessedNumber()
        {
            var enterednumber = _guessNumber.GetGuessedNumber() + 100;
            Assert.AreEqual(CompareResults.Great, _guessNumber.CompareWithGuessedNumber(enterednumber));
        }

        [TestMethod]
        public void IsGuessedNumberGeneratingRandomly()
        {
            var guessedNumber = _guessNumber.GetGuessedNumber();
            _guessNumber.GenerateNumber();
            var newGuessedNumber = _guessNumber.GetGuessedNumber();
            Assert.AreNotEqual(guessedNumber, newGuessedNumber);
        }

        [TestMethod]
        public void IsWonWhenEnteredNumberAreEqualGuessedNumber()
        {
            var enteredNumber = _guessNumber.GetGuessedNumber();
            _guessNumber.CompareWithGuessedNumber(enteredNumber);
            Assert.AreEqual(true, _guessNumber.IsWon);
        }

        [TestMethod]
        public void IsTriesAreZeroInTheBeginning()
        {
            Assert.AreEqual(0, _guessNumber.CountTries);
        }

        [TestMethod]
        public void IsEnteredNumberLessOrEqualMaxValue()
        {
            Assert.AreEqual(true, _guessNumber.CheckEnteredNumber(100));
            Assert.AreEqual(true, _guessNumber.CheckEnteredNumber(50));
            Assert.AreEqual(false, _guessNumber.CheckEnteredNumber(400));
        }

        [TestMethod]
        public void IsEnteredNumberGreaterOrEqualMinValue()
        {
            Assert.AreEqual(true, _guessNumber.CheckEnteredNumber(0));
            Assert.AreEqual(true, _guessNumber.CheckEnteredNumber(50));
            Assert.AreEqual(false, _guessNumber.CheckEnteredNumber(-50));
        }

        [TestMethod]
        public void IsTriesIsIncrementWhenYouTryToGuessNumber()
        {
            _guessNumber.CompareWithGuessedNumber(0);
            Assert.AreEqual(1, _guessNumber.CountTries);
            _guessNumber.CompareWithGuessedNumber(25);
            _guessNumber.CompareWithGuessedNumber(35);
            Assert.AreEqual(3, _guessNumber.CountTries);
        }

        [TestMethod]
        public void IsGameEndWhenTriesEqualToMaxTries()
        {
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            Assert.AreEqual(false, _guessNumber.IsGameEnd);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            _guessNumber.CompareWithGuessedNumber(0);
            Assert.AreEqual(true, _guessNumber.IsGameEnd);
        }

        [TestMethod]
        public void IsMaxTriesEqualTen()
        {
            Assert.AreEqual(10, _guessNumber.GetMaxTries());
        }

        [TestMethod]
        public void IsGuessNumberMinValueIsZero()
        {
            Assert.AreEqual(0, _guessNumber.GetNumberMinValue());
        }

        [TestMethod]
        public void IsGuessNumberMaxValueIsHundred()
        {
            Assert.AreEqual(100, _guessNumber.GetNumberMaxValue());
        }
    }
}
