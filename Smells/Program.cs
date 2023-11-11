using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Smells;

namespace MooGame;

class Program
{

    public static void Main(string[] args)
    {
        //Dependency injection
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context,services) =>
            {
                services.AddTransient<IGameLogic,GameLogic>();
                services.AddTransient<IResult, Result>();
                services.AddTransient<IUserInterface, UserInterface>();
                services.AddTransient<IGameController, GameController>();
            })
            .Build();

        //Creates a GameController instance
        var svc = ActivatorUtilities.CreateInstance<GameController>(host.Services);
        svc.Run();
    }
}