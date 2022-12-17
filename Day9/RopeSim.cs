using System;
namespace Day9
{
	public class RopeSim
	{
        private PositionSet _head;
        private PositionSet _tail;
        private List<PositionSet> _rope;

        public List<string> PositionStrings { get; set; }

        public RopeSim()
		{
            // Part 1
            PositionStrings = new List<string>();
			_head = new PositionSet();
			_tail = new PositionSet();
            AddPositionString(_tail);

            // Part 2
            _rope = new List<PositionSet>();
            for (int i = 1; i <= 10; i++)
                _rope.Add(new PositionSet());
        }

		public void ExecuteCommand(MovementCommand command)
		{
			MoveHead(command, this._head);
        }

		public void MoveHead(MovementCommand command, PositionSet head)
		{
			int steps = command.MovementDistance;
			for (int index = 0; index < steps; index++)
			{
				if (command.MovementDirection == Direction.Up)
					head.YPosition++;
                else if (command.MovementDirection == Direction.Down)
                    head.YPosition--;
                else if (command.MovementDirection == Direction.Right)
                    head.XPosition++;
                else if (command.MovementDirection == Direction.Left)
                    head.XPosition--;

                FollowLeading(_head, _tail);
                AddPositionString(_tail);
            }
		}

        public void AddPositionString(PositionSet positionSet)
        {
            string pos = positionSet.GetPositionString();
            if (!PositionStrings.Contains(pos))
                PositionStrings.Add(pos);
        }

		public void FollowLeading(PositionSet leading, PositionSet trailing)
		{
            int distanceY = leading.YPosition - trailing.YPosition;
            int distanceX = leading.XPosition - trailing.XPosition;

            if (Math.Abs(distanceY) <= 1 && Math.Abs(distanceX) <= 1)
            {
                // touching distance, don't move
                return;
            }

            // Follow straight horizontal
            if (distanceY == 0)
			{
				if (distanceX > 1)
                    trailing.XPosition++;
                else if (distanceX < -1)
                    trailing.XPosition--;
            }
            // Follow straight vertical
            else if (distanceX == 0)
            {
                if (distanceY > 1)
                    trailing.YPosition++;
                else if (distanceY < -1)
                    trailing.YPosition--;
            }
            else if (distanceX == -2 && distanceY == 1) // a
            {
                trailing.YPosition++;
                trailing.XPosition--;
            }
            else if (distanceX == -2 && distanceY == -1) // h
            {
                trailing.YPosition--;
                trailing.XPosition--;
            }
            else if (distanceX == -1 && distanceY == 2) // b
            {
                trailing.YPosition++;
                trailing.XPosition--;
            }
            else if (distanceX == 1 && distanceY == 2) // c
            {
                trailing.YPosition++;
                trailing.XPosition++;
            }
            else if (distanceX == 2 && distanceY == 1) // d
            {
                trailing.YPosition++;
                trailing.XPosition++;
            }
            else if (distanceX == 2 && distanceY == -1) // e
            {
                trailing.YPosition--;
                trailing.XPosition++;
            }
            else if (distanceX == 1 && distanceY == -2) // f-
            {
                trailing.YPosition--;
                trailing.XPosition++;
            }
            else if (distanceX == -1 && distanceY == -2) // g
            {
                trailing.YPosition--;
                trailing.XPosition--;
            }


            else if (distanceX == -2 && distanceY == 2) // k
            {
                trailing.YPosition++;
                trailing.XPosition--;
            }
            else if (distanceX == 2 && distanceY == 2) // l
            {
                trailing.YPosition++;
                trailing.XPosition++;
            }
            else if (distanceX == 2 && distanceY == -2) // m
            {
                trailing.YPosition--;
                trailing.XPosition++;
            }
            else if (distanceX == -2 && distanceY == -2) // m
            {
                trailing.YPosition--;
                trailing.XPosition--;
            }
        }

		public void PrintPositions()
		{
			Console.WriteLine($"Head {_head.XPosition},{_head.YPosition} Tail {_tail.XPosition},{_tail.YPosition}");
		}

        public void ExecuteCommand_Part2(MovementCommand command)
        {
            MoveRope(command);
            Console.WriteLine($"Head {_rope[0].XPosition},{_rope[0].YPosition}");
            Console.WriteLine($"Tail 1 {_rope[1].XPosition},{_rope[1].YPosition}");
            Console.WriteLine($"Tail 2 {_rope[2].XPosition},{_rope[2].YPosition}");
            Console.WriteLine($"Tail 3 {_rope[3].XPosition},{_rope[3].YPosition}");
            Console.WriteLine($"Tail 4 {_rope[4].XPosition},{_rope[4].YPosition}");
            Console.WriteLine($"Tail 5 {_rope[5].XPosition},{_rope[5].YPosition}");
            Console.WriteLine($"Tail 6 {_rope[6].XPosition},{_rope[6].YPosition}");
            Console.WriteLine($"Tail 7 {_rope[7].XPosition},{_rope[7].YPosition}");
            Console.WriteLine($"Tail 8 {_rope[8].XPosition},{_rope[8].YPosition}");
            Console.WriteLine($"Tail 9 {_rope[9].XPosition},{_rope[9].YPosition}");
        }

        public void MoveRope(MovementCommand command)
        {
            var head = _rope[0];

            int steps = command.MovementDistance;
            for (int index = 0; index < steps; index++)
            {
                if (command.MovementDirection == Direction.Up)
                    head.YPosition++;
                else if (command.MovementDirection == Direction.Down)
                    head.YPosition--;
                else if (command.MovementDirection == Direction.Right)
                    head.XPosition++;
                else if (command.MovementDirection == Direction.Left)
                    head.XPosition--;

                for (int i = 0; i <= 8 ; i++)
                    FollowLeading(_rope[i], _rope[i + 1]);

                AddPositionString(_rope[9]);
            }
        }
    }
}

