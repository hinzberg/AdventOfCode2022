using Advent1;

// The Elves take turns writing down the number of Calories contained by the various meals, snacks, rations, etc.
// that they've brought with them, one item per line.
// Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line.

Console.WriteLine("Day 1: Calorie Counting");

string path = @"input.txt";

List<Elf> elves = new List<Elf>();
Elf currentElf = new Elf();
elves.Add(currentElf);

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            currentElf = new Elf();
            elves.Add(currentElf);
        }
        else
        {
            int cal = int.Parse(line);
            currentElf.Calories += cal;
        }
    }
}

// Part 1
// Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?

var topElf = elves.OrderByDescending(a => a.Calories).First();
Console.WriteLine("Top Elf: " + topElf.Calories);

// Part 2
// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
var topElves = elves.OrderByDescending(a => a.Calories).Take(3);
var topElvesCalories = topElves.Sum(a => a.Calories);
Console.WriteLine("Top Elves Calories: " + topElvesCalories);
