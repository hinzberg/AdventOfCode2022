// See https://aka.ms/new-console-template for more information
using Day2;
Console.WriteLine("Advent of Code - Day 2");

string path = @"input.txt";

List<GameRound> rounds = new List<GameRound>();

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            string elf = line.Substring(0, 1);
            string player = line.Substring(2, 1);
            GameRound gr = new GameRound(elf, player);
            rounds.Add(gr);
        }
    }
}

Console.WriteLine($"Game 1");
Game game = new Game();
//game.PlayGame(rounds);
Console.WriteLine($"Elf Score ; {game.ElfScore}");
Console.WriteLine($"Player Score ; {game.PlayerScore}");

game.AdjustSelectionForGame2(rounds);
game.PlayGame(rounds);

Console.WriteLine($"Elf Score ; {game.ElfScore}");
Console.WriteLine($"Player Score ; {game.PlayerScore}");

Console.WriteLine("Done!");