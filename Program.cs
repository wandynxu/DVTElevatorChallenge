using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using Building.Services;
using Building.Services.Contracts;
using Building.Commands.ElevatorControl;

var service = new ServiceCollection()
    .AddSingleton<IElevatorControlService, ElevatorControlService>()
    .BuildServiceProvider();

//Spectre Console Settings
var app = new CommandApp();
app.Configure(c =>
{
    c.AddCommand<ElevatorTypesCommand>("elevator-types");
    /*
    c.AddBranch("elevator-types", elevator =>
    {
        
        elevator.AddBranch("select-floor", create =>
        {
            create.AddCommand<FloorCommand>("floor");
        });

    });
    */
});

await app.RunAsync(args);