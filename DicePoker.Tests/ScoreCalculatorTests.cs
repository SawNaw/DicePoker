using Xunit;
using DicePoker.Core;
using Moq;

namespace DicePoker.Tests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void FourOfAKind_Gets100Points()
        {
            var diceRoll = GetDiceRollWithResult(3);

            var sut = new ScoreCalculator(diceRoll,
                                          diceRoll,
                                          diceRoll,
                                          diceRoll);

            Assert.Equal(100, sut.CalculateScore());
        }

        [Fact]
        public void Straight_Gets50Points()
        {
            var diceRoll1 = GetDiceRollWithResult(1);
            var diceRoll2 = GetDiceRollWithResult(2);
            var diceRoll3 = GetDiceRollWithResult(3);
            var diceRoll4 = GetDiceRollWithResult(4);

            var sut = new ScoreCalculator(diceRoll1,
                                          diceRoll2,
                                          diceRoll3,
                                          diceRoll4);

            Assert.Equal(50, sut.CalculateScore());
        }

        [Fact]
        public void ThreeOfAKind_Gets25Points()
        {
            var diceRoll = GetDiceRollWithResult(1);
            var otherDiceRoll = GetDiceRollWithResult(2);

            var sut = new ScoreCalculator(diceRoll,
                                          diceRoll,
                                          diceRoll,
                                          otherDiceRoll);

            Assert.Equal(25, sut.CalculateScore());
        }

        [Fact]
        public void TwoOfAKind_Gets10Points()
        {
            var diceRoll = GetDiceRollWithResult(1);
            var otherDiceRoll = GetDiceRollWithResult(2);

            var sut = new ScoreCalculator(diceRoll,
                                          diceRoll,
                                          otherDiceRoll,
                                          otherDiceRoll);

            Assert.Equal(10, sut.CalculateScore());
        }

        [Fact]
        public void DefaultScore_IsHighestDiceValue()
        {
            var diceRoll1 = GetDiceRollWithResult(1);
            var diceRoll3 = GetDiceRollWithResult(3);
            var diceRoll4 = GetDiceRollWithResult(4);
            var diceRoll5 = GetDiceRollWithResult(5);

            var sut = new ScoreCalculator(diceRoll1,
                                          diceRoll3,
                                          diceRoll4,
                                          diceRoll5);

            Assert.Equal(5, sut.CalculateScore());
        }

        private IDiceRollResult GetDiceRollWithResult(int result)
        {
            var diceRoll = new Mock<IDiceRollResult>();
            diceRoll.Setup(d => d.Result).Returns(result);

            return diceRoll.Object;
        }
    }
}