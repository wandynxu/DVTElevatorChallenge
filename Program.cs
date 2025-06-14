using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using Building.Services;
using Building.Services.Contracts;
using Building.Commands.ElevatorControl;
using Building.Commands.DI;
using Elevator.Classes.Concretes;

//Inject Services to Spectre Console Commands
static ITypeRegistrar RegisterServices()
{
    var services = new ServiceCollection()
                        .AddSingleton<IElevatorControlService<DumbWaiter>, ElevatorControlService<DumbWaiter>>()
                        .AddSingleton<IElevatorControlService<Emergency>, ElevatorControlService<Emergency>>()
                        .AddSingleton<IElevatorControlService<Freight>, ElevatorControlService<Freight>>()
                        .AddSingleton<IElevatorControlService<Passenger>, ElevatorControlService<Passenger>>()
                        .AddSingleton<IElevatorControlService<Service>, ElevatorControlService<Service>>()
                        .AddSingleton<IElevatorControlService<Sidewalk>, ElevatorControlService<Sidewalk>>();

    return new CommandTypeRegistrar(services);
}

static IConfigurator ConfigureCommands(IConfigurator config)
{
    config.CaseSensitivity(CaseSensitivity.None);
    config.SetApplicationName("DVT Elevator Challenge");
    
    config.AddCommand<InteractiveElevatorControl>("elevator-control")
          .WithDescription("Pick elevator type from list, then input floor number.");

    return config;
}


//Spectre Console
var app = new CommandApp(RegisterServices());
app.Configure(config => ConfigureCommands(config));
return app.Run(args);