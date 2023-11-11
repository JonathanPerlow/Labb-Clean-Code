using Smells;

namespace TestSmell
{
    [TestClass]
    public class TestGameLogic
    {
        [TestMethod]
        public void Test_CheckBC_CorrectAnswer()
        {
            IGameLogic gameLogic = new GameLogic();
            Assert.AreEqual("BBBB,", gameLogic.checkBC("4532", "4532"));
        }

        [TestMethod]
        public void Test_CheckBC_IncorrectAnswer()
        {
            IGameLogic gameLogic = new GameLogic();
            Assert.AreNotEqual("BBB", gameLogic.checkBC("4532", "4532"));
        }

        [TestMethod]
        public void Test_CheckBC_HalfRightAnswer()
        {
            IGameLogic gameLogic = new GameLogic();
            Assert.AreEqual("BB,CC", gameLogic.checkBC("4532", "4523"));

        }


        [TestMethod]
        public void Test_Goal_GeneratesFourDigits()
        {
            IGameLogic gameLogic = new GameLogic();
            Assert.AreEqual(4, gameLogic.makeGoal().Length);
        }

    }
}