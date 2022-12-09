using System;
namespace Day7
{
	public class AdvDirectory
	{
		public string DirectoryName { get; set; }
		public AdvDirectory? ParentDirectory { get; set; }
        public List<AdvDirectory> ChildDirectories { get; set; }
		public List<AdvFile> Files { get; set; }
		public int Size { get; set; }

        public AdvDirectory(string directoryName, AdvDirectory? parent)
		{
			DirectoryName = directoryName;
			ParentDirectory = parent;
			ChildDirectories = new List<AdvDirectory>();
			Files = new List<AdvFile>();
			Size = 0;
		}

		public AdvDirectory AddChildDirectory(string directoryName)
		{
			var existingDir = this.ChildDirectories.Where(a => a.DirectoryName == directoryName).FirstOrDefault();
			if (existingDir != null)
				return existingDir;

           AdvDirectory child = new AdvDirectory(directoryName, this);
			this.ChildDirectories.Add(child);
			return child;
		}

		public void AddFile(string fileName, string fileSize)
		{
			int size = int.Parse(fileSize);
			AdvFile file = new AdvFile() { FileName = fileName, FileSize = size };
			Files.Add(file);
		}
	}
}

