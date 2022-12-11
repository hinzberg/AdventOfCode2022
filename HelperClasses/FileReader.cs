using System;

namespace HelperClasses
{
	public static class FileReader
	{
		public static List<string> Read(string fileName)
		{
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }
	}
}

