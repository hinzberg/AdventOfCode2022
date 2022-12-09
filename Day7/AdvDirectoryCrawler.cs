using System;
namespace Day7
{
    public class AdvDirectoryCrawler
    {
        private AdvDirectory _root = new AdvDirectory("/", null);
        private AdvDirectory _currentDirectory;
        private List<AdvDirectory> _directoryList = new List<AdvDirectory>();
        private const int _directorySizeThreshold = 100000;
        private const int _totalDiskSpace = 70000000;
        private const int _freeDiskSpaceNeeded = 30000000;

        public AdvDirectoryCrawler()
        {
            _currentDirectory = _root;
        }

        public void ParseCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;

            if (command.Substring(0, 4) == "$ cd")
            {
                ParseDirectoryCommands(command);
            }
            else if (command == "$ ls" || command.Substring(0, 3) == "dir")
            {
                // Nothing to do
            }
            else 
            {
                // Everything else is a file
                AddFile(command);
            }
        }

        private void ParseDirectoryCommands(string command)
        {
            if (command == "$ cd /")
            {
                Console.WriteLine("Move to root");
                _currentDirectory = _root;
            }
            else if (command == "$ cd ..")
            {
                if (_currentDirectory.ParentDirectory != null)
                {
                    _currentDirectory = _currentDirectory.ParentDirectory;
                    Console.WriteLine($"Move to parent {_currentDirectory.DirectoryName}");
                }
            }
            else
            {
                var subDir = command.Substring(5, command.Length - 5);
                Console.WriteLine($"Move to sub {subDir}");
                _currentDirectory = _currentDirectory.AddChildDirectory(subDir);
                if (!_directoryList.Contains(_currentDirectory))
                    _directoryList.Add(_currentDirectory);
            }
        }

        private void AddFile(string command)
        {
            var parts = command.Split(" ");
            Console.WriteLine($"Add file '{parts[1]}' to '{_currentDirectory.DirectoryName}'");
            _currentDirectory.AddFile(parts[1], parts[0]);
        }

        public int GetTotalSizeOfRootDirectory()
        {
            // Part1
            int totalRoot = GetTotalSizeOfDirectory(_root);
            Console.WriteLine($"Total size of root {totalRoot}");

            var t = _directoryList.Where(x => x.Size <= 100000).Sum(a => a.Size);
            Console.WriteLine($"Sum over threshold {t}");

            return totalRoot;
        }

        public void FindSmallestDirectoryToDelete(int currentSpaceUsed)
        {
            // Part2
            int actualFreeSpace = _totalDiskSpace - currentSpaceUsed;
            int spaceNeededDeletion = _freeDiskSpaceNeeded - actualFreeSpace;
            Console.WriteLine($"More Space needed: {spaceNeededDeletion}");

            var smallestDirToDelete = _directoryList.Where(a => a.Size >= spaceNeededDeletion).OrderBy( x => x.Size).First();
            Console.WriteLine($"Delete this: {smallestDirToDelete.DirectoryName} {smallestDirToDelete.Size}");
        }

        private int GetTotalSizeOfDirectory(AdvDirectory directory)
        {
            int size = 0;

            foreach (var file in directory.Files)
                size += file.FileSize;

            foreach (var dir in directory.ChildDirectories)
                size += GetTotalSizeOfDirectory(dir);

            directory.Size = size;
            Console.WriteLine($"{directory.DirectoryName} Size: {directory.Size}");
            return size;
        }
    }
}

