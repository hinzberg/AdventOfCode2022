using System;
namespace Day9
{
	public class PositionSet
	{
		public int XPosition { get; set; }
		public int YPosition { get; set; }

		public PositionSet()
		{
			this.XPosition = 0;
			this.YPosition = 0;
		}

		public string GetPositionString()
		{
			return $"{this.XPosition}, {this.YPosition}";
		}
	}
}

