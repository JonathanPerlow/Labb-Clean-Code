namespace Smells
{
    public class UserInterface : IUserInterface
    {
        private readonly IGameLogic _game;
        private readonly IResult _result;
        public UserInterface(IGameLogic game, IResult result)
        {
            _game = game;
            _result = result;
        }

        public void UserInteraction()
        {
            bool playOn = true;
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();

            while (playOn)
            {
                string goal = _game.makeGoal();

                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + goal + "\n");

                string guess = CheckUserGuess();
                int nGuess = 1;
                string bullsAndCows = _game.checkBC(goal, guess);
                Console.WriteLine(bullsAndCows + "\n");

                while (bullsAndCows != "BBBB,")
                {
                    nGuess++;
                    guess = CheckUserGuess();
                    bullsAndCows = _game.checkBC(goal, guess);
                    Console.WriteLine(bullsAndCows + "\n");
                }

                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + nGuess);
                output.Close();

                _result.Show();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nPress enter to continue playing or n to stop?");
                string answer = Console.ReadLine();

                if (!String.IsNullOrEmpty(answer) && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }
        public static string CheckUserGuess()
        {
            string userGuess = "";
            int allowedLength = 4;
            while(true)
            {
                userGuess = Console.ReadLine();
                int userGuessLength = userGuess.Length;

                try
                {
                    Convert.ToInt32(userGuess);
                    LengthCheck(userGuessLength, allowedLength);
                    break;
                }
                catch
                {
                    Console.WriteLine("Your guess is not a number or is not 4 numbers. Try again\n");
                }
            }
            return userGuess;
        }

        private static void LengthCheck(int userGuessLength, int allowedLength)
        {
            if(userGuessLength != allowedLength) 
            {
                throw new Exception();
            }
        }
    }
}
