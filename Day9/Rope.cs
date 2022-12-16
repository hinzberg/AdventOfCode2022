using System;
namespace Day9
{
	public class Rope
	{
		public PositionSet Head { get; set; }
		public PositionSet Tail { get; set; }

        public List<string> PositionStrings { get; set; }

        public Rope()
		{
            this.PositionStrings = new List<string>();
			this.Head = new PositionSet();
			this.Tail = new PositionSet();
            AddPositionString();
        }

		public void ExecuteCommand(MovementCommand command)
		{
			MoveHead(command);
		}

		public void MoveHead(MovementCommand command)
		{
			int steps = command.MovementDistance;
			for (int index = 0; index < steps; index++)
			{
				if (command.MovementDirection == Direction.Up)
					Head.YPosition++;
                else if (command.MovementDirection == Direction.Down)
                    Head.YPosition--;
                else if (command.MovementDirection == Direction.Right)
                    Head.XPosition++;
                else if (command.MovementDirection == Direction.Left)
                    Head.XPosition--;

				FollowTail();
                AddPositionString();
            }
		}

        public void AddPositionString()
        {
            string pos = this.Tail.GetPositionString();
            if (!PositionStrings.Contains(pos))
                PositionStrings.Add(pos);
        }

		public void FollowTail()
		{
            int distanceY = Head.YPosition - Tail.YPosition;
            int distanceX = Head.XPosition - Tail.XPosition;

            if (Math.Abs(distanceY) <= 1 && Math.Abs(distanceX) <= 1)
            {
                // touching distance, don't move
                return;
            }

            // Follow straight horizontal
            if (distanceY == 0)
			{
				if (distanceX > 1)
	                Tail.XPosition++;
                else if (distanceX < -1)
                    Tail.XPosition--;
            }
            // Follow straight vertical
            else if (distanceX == 0)
            {
                if (distanceY > 1)
                    Tail.YPosition++;
                else if (distanceY < -1)
                    Tail.YPosition--;
            }
            else if (distanceX == -2 && distanceY == 1) // a
            {
                Tail.YPosition++;
                Tail.XPosition--;
            }
            else if (distanceX == -2 && distanceY == -1) // h
            {
                Tail.YPosition--;
                Tail.XPosition--;
            }
            else if (distanceX == -1 && distanceY == 2) // b
            {
                Tail.YPosition++;
                Tail.XPosition--;
            }
            else if (distanceX == 1 && distanceY == 2) // c
            {
                Tail.YPosition++;
                Tail.XPosition++;
            }
            else if (distanceX == 2 && distanceY == 1) // d
            {
                Tail.YPosition++;
                Tail.XPosition++;
            }
            else if (distanceX == 2 && distanceY == -1) // e
            {
                Tail.YPosition--;
                Tail.XPosition++;
            }

            else if (distanceX == 1 && distanceY == -2) // f
            {
                Console.WriteLine("f");
                Tail.YPosition--;
                Tail.XPosition++;
            }
            else if (distanceX == -1 && distanceY == -2) // g
            {
                Tail.YPosition--;
                Tail.XPosition--;
            }
        }

		public void PrintPositions()
		{
			Console.WriteLine($"Head {Head.XPosition},{Head.YPosition} Tail {Tail.XPosition},{Tail.YPosition}");
		}
	}
}

