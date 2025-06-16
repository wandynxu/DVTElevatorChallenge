# DVTElevatorChallenge

## Overview

DVTElevatorChallenge is a simulation of elevator operations in a multi-floor building. The application allows users to interactively select elevator types, set floors, and simulate elevator movement using a console interface.

## Features

- Multiple elevator types: Passenger, Freight, Service, Emergency, DumbWaiter, Sidewalk
- Floor and weight/passenger limits per elevator type
- Interactive CLI using Spectre.Console
- Dependency injection with Microsoft.Extensions.DependencyInjection

## Project Structure

- `src/` - Main application source code
  - `Classes/` - Elevator type definitions
  - `Commands/` - Elevator control logic
  - `ConsoleUI/` - Console interface and settings
  - `Enums/` - Enumerations for elevator properties
  - `Models/` - Data models
- `tests/` - Unit tests

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Build and Run

1. Navigate to the `src` directory:
   ```sh
   cd src
   ```
2. Build the project:
   ```sh
   dotnet build
   ```
3. Run the application:
   ```sh
   dotnet run elevator
   ```

## Usage

Follow the interactive prompts in the console to:
- Select an elevator type
- Set elevator speed (if applicable)
- Enter current and target floors
- Specify number of passengers or weight of goods

## Dependencies

- [Spectre.Console](https://spectreconsole.net/)
- [Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

## License

This project is for DVT