using Day7;

Console.WriteLine("Day 7: No Space Left On Device");

/*
string input = "$ cd /\n";
input += "$ ls\n";
input += "dir a\n";
input += "14848514 b.txt\n";
input += "8504156 c.dat\n";
input += "dir d\n";
input += "$ cd a\n";
input += "$ ls\n";
input += "dir e\n";
input += "29116 f\n";
input += "2557 g\n";
input += "62596 h.lst\n";
input += "$ cd e\n";
input += "$ ls\n";
input += "584 i\n";
input += "$ cd ..\n";
input += "$ cd ..\n";
input += "$ cd d\n";
input += "$ ls\n";
input += "4060174 j\n";
input += "8033020 d.log\n";
input += "5626152 d.ext\n";
input += "7214296 k\n";
*/

string path = @"input.txt";
string content = string.Empty;

AdvDirectoryCrawler crawler = new AdvDirectoryCrawler();

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            crawler.ParseCommand(line);
        }
    }
}

int currentSpaceUsed = crawler.GetTotalSizeOfRootDirectory();
crawler.FindSmallestDirectoryToDelete(currentSpaceUsed);


Console.WriteLine("Done");
