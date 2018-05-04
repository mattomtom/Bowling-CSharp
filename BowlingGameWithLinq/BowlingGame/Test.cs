using NUnit.Framework;
using System;
namespace BowlingGame
{
    [TestFixture()]
    public class GameTest
    {
        Game game;

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
        public void GutterGame()
        {
            for (int i = 0; i < 20; i++)
                game.Roll(0);
            
            Assert.AreEqual(0, game.Score());
        }

        [Test()]
        public void SinglePinGame()
        {
            for (int i = 0; i < 20; i++)
                game.Roll(1);

            Assert.AreEqual(20, game.Score());
        }

        [Test()]
        public void SpareGame()
        {
            game.Roll(5);
            game.Roll(5); // spare

            game.Roll(2);

            Assert.AreEqual(14, game.Score());
        }

        [Test()]
        public void NoSpareGame()
        {
            game.Roll(2);
            game.Roll(5);

            game.Roll(5);
            game.Roll(2);

            Assert.AreEqual(14, game.Score());
        }

        [Test()]
        public void StrikeGame()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(6);

            Assert.AreEqual(24, game.Score());
        }
    }
}
