using System;
using Xunit;

namespace GreedKata.Tests
{
    public class GreedGameTests
    {
        [Fact]
        public void Score_InputRollWithNoApplicableRule_ScoresZeroPoints()
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(new int[5] { 2, 3, 4, 6, 2 });

            Assert.Equal(0, score);
        }

        [Theory]
        [InlineData(new int[5] { 1, 3, 4, 4, 2 },100)]
        [InlineData(new int[5] { 1, 3, 4, 1, 2 },200)]
        public void Score_InputRollWithOne_ScoresOneHundredPoints(int [] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[5] { 1, 3, 1, 1, 2 }, 1000)]
        public void Score_InputRollWithTripleOne_ScoresOneThousandPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[5] { 6, 3, 2, 5, 3 }, 50)]
        [InlineData(new int[5] { 6, 5, 2, 5, 3 }, 100)]
        public void Score_InputRollWithFive_ScoresFiftyPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[5] { 6, 5, 2, 5, 5 }, 500)]
        public void Score_InputRollWithTripleFive_ScoresFiveHundredPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[5] { 6, 3, 2, 3, 3 }, 300)]
        [InlineData(new int[5] { 4, 4, 4, 3, 3 }, 400)]
        [InlineData(new int[5] { 2, 4, 2, 3, 2 }, 200)]
        public void Score_InputRollWithTriple_ScoresBaseMultiplyHundredPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[6] { 2, 2, 2, 2, 4, 6 }, 400)]
        public void Score_InputFourOfKind_ScoresTwoTriplePoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[6] { 2, 2, 2, 2, 2, 6 }, 800)]
        public void Score_InputFiveOfKind_ScoresFourTriplePoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[6] { 2, 2, 2, 2, 2, 2 }, 1600)]
        public void Score_InputSixOfKind_ScoresEightTriplePoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[6] { 2, 2, 3, 3, 4, 4 }, 800)]
        public void Score_ThreePairs_ScoresThreePairsPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData(new int[6] { 1, 2, 3, 4, 5, 6 }, 1200)]
        public void Score_Straight_ScoresOneThousandTwoHundredPoints(int[] roll, int expected)
        {
            var greedGame = new GreedGame();

            var score = greedGame.Score(roll);

            Assert.Equal(expected, score);
        }
    }
}
