using Day7;
using HelperClasses;

Console.WriteLine("Day 7: No Space Left On Device");

string path = @"input.txt";

AdvDirectoryCrawler crawler = new AdvDirectoryCrawler();

List<string> lines = FileReader.Read(path);
foreach (var line in lines)
    crawler.ParseCommand(line);

int currentSpaceUsed = crawler.GetTotalSizeOfRootDirectory();
crawler.FindSmallestDirectoryToDelete(currentSpaceUsed);

Console.WriteLine("Done");
