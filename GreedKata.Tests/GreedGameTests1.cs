
using System.Linq;
using Xunit;

namespace GreedKata.Tests
{
    public class GreedGameTests1
    {
        [Fact]
        public void Score_NoInput_ScoresZero()
        {
            var greedGame = new GreedGame1();

            var result = greedGame.Score(new() { 2, 2, 3, 4, 6, 6});

            Assert.Equal(0, result);
        }

        private static void TestScore(int expected, int[] input)
        {
            var greedGame = new GreedGame1();

            var result = greedGame.Score(input.ToList());

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 1, 2, 3, 4, 2, 6)]
        [InlineData(200, 1, 2, 3, 4, 1, 6)]
        public void Score_SingleOnes_ScoresOnehundreds(int expected, params int[] input)
        {
            TestScore(expected, input);
        }

        [Theory]
        [InlineData(50, 5, 2, 3, 4, 2, 6)]
        [InlineData(100, 5, 2, 3, 4, 5, 6)]
        public void Score_SingleFives_ScoresFifties(int expected, params int[] input)
        {
            TestScore(expected, input);
        }

        [Theory]
        [InlineData(400, 4, 2, 4, 4, 3, 6)]
        [InlineData(200, 2, 2, 3, 4, 2, 6)]
        public void Score_TriplesNoTripleOneOrFive_ScoresTriples(int expected, params int[] input)
        {
            TestScore(expected, input);
        }

        [Theory]
        [InlineData(500, 5, 2, 5, 5, 3, 6)]
        public void Score_TriplesFive_ScoresTriples(int expected, params int[] input)
        {
            TestScore(expected, input);
        }

        [Theory]
        [InlineData(1000, 1, 2, 1, 1, 3, 6)]
        public void Score_TriplesOne_ScoresTriples(int expected, params int[] input)
        {
            TestScore(expected, input);
        }

    }
}
