namespace Smells
{
    public class GameController : IGameController
    {
        private readonly IUserInterface _userInterface;
        public GameController(IUserInterface userInterface) => _userInterface = userInterface;

        public void Run() => _userInterface.UserInteraction();
    }
}
