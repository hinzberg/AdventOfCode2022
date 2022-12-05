using Day5;

Console.WriteLine("Day 5: Supply Stacks");

string path = @"input.txt";

List<Instruction> instructions = new List<Instruction>();
Stacker stacker = new Stacker();

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line) && line.StartsWith("["))
        {
            stacker.Parser(line);
        }
        else if (!string.IsNullOrEmpty(line) && line.StartsWith("move"))
        {
            instructions.Add(new Instruction(line));
        }
    }
}

stacker.PrintStacks();

foreach (var instruction in instructions)
{
    Console.WriteLine(instruction.Text);
    stacker.ExcecuteInstruction(instruction);
    stacker.PrintStacks();
}

stacker.PrintTopStacks();
Console.WriteLine("Done");


