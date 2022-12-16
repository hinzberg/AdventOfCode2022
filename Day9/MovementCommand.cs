using System;
namespace Day9
{
	public enum Direction
	{
		None,Up,Down,Left,Right
	}

	public class MovementCommand
	{
		public Direction MovementDirection { get; set; }
		public int MovementDistance { get; set; }

		public MovementCommand(string line)
		{
            this.MovementDirection = Direction.None;
            this.MovementDistance = 0;

            string[] parts = line.Split(" ");

			if (parts[0] == "U")
				this.MovementDirection = Direction.Up;
            else if (parts[0] == "D")
                this.MovementDirection = Direction.Down;
            else if (parts[0] == "L")
                this.MovementDirection = Direction.Left;
            else if (parts[0] == "R")
                this.MovementDirection = Direction.Right;

			this.MovementDistance = int.Parse(parts[1]);
        }
	}
}

