using System;
namespace Day5
{
	public class Instruction
	{
		public int Count { get; set; }
		public int FromStack { get; set; }
		public int ToStack { get; set; }
		public string Text { get; set; }

		public Instruction(string line)
		{
			Text = line;
			line = line.Replace("move","");
            line = line.Replace("from", ";");
            line = line.Replace("to", ";");
			var array = line.Split(";");

			Count = int.Parse(array[0].Trim());
            FromStack = int.Parse(array[1].Trim());
            ToStack = int.Parse(array[2].Trim());
        }
	}
}
