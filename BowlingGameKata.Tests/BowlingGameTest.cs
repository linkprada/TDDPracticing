using System;
using Xunit;

namespace BowlingGameKata.Tests
{
    public class BowlingGameTest
    {
        public Game game { get; set; }
        public BowlingGameTest()
        {
            game = new Game();
        }

        [Fact]
        public void AllRollsWithZeroPin()
        {
            RollMany(20, 0);

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void AllRollsWithOnePin()
        {
            RollMany(20, 1);

            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void RollWithOneSpare()
        {
            RollSpare();
            game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void RollWithOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);

            RollMany(16, 0);

            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void AllRollsAreStrikes() 
        { 
            RollMany(12,10);

            Assert.Equal(300, game.Score());
        }

        private void RollMany(int rollsNumber, int pins)
        {
            for (int i = 0; i < rollsNumber; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
        
        private void RollStrike()
        {
            game.Roll(10);
        }
    }
}
