using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using Building.Commands;
using Building.ConsoleUI.DI;
using Building.ConsoleUI;


//Inject Services to Spectre Console Commands
static ITypeRegistrar RegisterServices()
{
    var services = new ServiceCollection()
                       .AddSingleton<IElevatorControl, ElevatorControl>()
                       .AddSingleton<ElevatorState>();
                   
    return new CommandTypeRegistrar(services);
}

static IConfigurator ConfigureCommands(IConfigurator config)
{
    config.CaseSensitivity(CaseSensitivity.None);
    config.SetApplicationName("DVT Elevator Challenge");
    
    config.AddCommand<InteractiveElevatorControl>("elevator")
          .WithDescription("Pick elevator type from list, then input floor number.");
    
    config.PropagateExceptions(); 

    return config;
}


//Spectre Console
var app = new CommandApp(RegisterServices());
app.Configure(config => ConfigureCommands(config));
return app.Run(args);