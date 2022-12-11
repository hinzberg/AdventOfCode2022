using HelperClasses;
using Day8;

Console.WriteLine("Day 8: Treetop Tree House");

string path = @"input.txt";

List<string> lines = FileReader.Read(path);
TreeParser parser = new TreeParser();
parser.Parse(lines);
// parser.OutputTree();
parser.SetVisibility();
Console.WriteLine($"\nVisible Trees : {parser.GetVisibleCount()}");
parser.CalculateScenicScore();
Console.WriteLine($"Highest Scenic Score : {parser.GetHighestScenicScore()}");

Console.WriteLine("Done");
