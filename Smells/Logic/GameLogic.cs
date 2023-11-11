namespace Smells
{
    public class GameLogic : IGameLogic
    {
        public string makeGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";

            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal += randomDigit;
            }
            return goal;
        }

        public string checkBC(string goal, string guess)
        {
            int cows = 0;
            int bulls = 0;
            int guessLength = guess.Length;

            for (int i = 0; i < guessLength; i++)
            {
                for (int j = 0; j < guessLength; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return string.Concat("BBBB".AsSpan(0, bulls), ",", "CCCC".AsSpan(0, cows));
        }
    }
}
