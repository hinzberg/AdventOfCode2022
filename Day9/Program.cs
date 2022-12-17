using HelperClasses;
using Day9;

Console.WriteLine("Day 9: Rope Bridge");

string path = @"input.txt";

List<string> lines = FileReader.Read(path);

List<MovementCommand> commands = new List<MovementCommand>();
foreach (var line in lines)
    commands.Add(new MovementCommand(line));

RopeSim rope = new RopeSim();
foreach (var command in commands)
    rope.ExecuteCommand_Part2(command);

Console.WriteLine($"Positions {rope.PositionStrings.Count()}");
Console.WriteLine("Done");

