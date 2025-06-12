using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using Building.Services;
using Building.Services.Contracts;

var service = new ServiceCollection()
    .AddSingleton<IElevatorControlService, ElevatorControlService>()
    .BuildServiceProvider();

//Spectre Console Settings
var app = new CommandApp();
