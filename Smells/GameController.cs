using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smells
{
    public class GameController
    {
        private readonly IGameLogic _game;
        private readonly IResult _result;
        public GameController(IGameLogic game, IResult result)
        {
            _game = game;
            _result = result;
        }
    }
}
