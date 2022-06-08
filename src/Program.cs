// See https://aka.ms/new-console-template for more information

using Exo3.Core;
using Exo3.Infrastructure;
using Exo3.Presentation;

var commandParser = new CommandParser();
var command = commandParser.Parse(Environment.GetCommandLineArgs());
var dataReader = new FileDataReader(command.FilePath);
var consolePrinter = new ConsolePrinter();
var computer = new Computer(dataReader, consolePrinter, command.Operation);
await computer.ComputeAsync();