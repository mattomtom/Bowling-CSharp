using NUnit.Framework;
using System;
namespace BowlingGameClassic
{
    [TestFixture()]
    public class Test
    {
        private Game game;
        
        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [TearDown]
        public void TearDown()
        {
            game = null;
        }

        [Test()]
        public void TestGutterGame()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [Test()]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [Test()]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);

            Assert.AreEqual(16, game.Score());
        }

        [Test()]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            Assert.AreEqual(24, game.Score());
        }

        [Test()]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
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
