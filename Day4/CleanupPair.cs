using System;
namespace Day4
{
	public class CleanupPair
	{
		private string _input;
		private string _firstPart;
		private string _secondPart;
		private Tuple<int, int> _firstRange;
		private Tuple<int, int> _secondRange;
		public bool DoesCompleteIntersect = false;
		public bool DoesPartialIntersect = false;

		public CleanupPair(string input)
		{
			var parts = input.Split(",");
			_input = input;
			_firstPart = parts[0];
			_secondPart = parts[1];
			_firstRange = GetRange(_firstPart);
			_secondRange = GetRange(_secondPart);
            DoesCompleteIntersect = CheckCompleteIntersection(_firstRange, _secondRange);
            DoesPartialIntersect = CheckPartialIntersection(_firstRange, _secondRange);
		}

		private Tuple<int, int> GetRange(string input)
		{
			var parts = input.Split("-");
			string startString = parts[0];
			string endString = parts[1];
			int start = int.Parse(startString);
			int end = int.Parse(endString);
			return new Tuple<int, int>(start, end);
		}

		private bool CheckCompleteIntersection(Tuple<int, int> range1, Tuple<int, int> range2)
		{
			// Range 1 contains Range 2
			if (range2.Item1 >= range1.Item1 && range2.Item2 <= range1.Item2)
				return true;

			// Range 2 contains Range 1
			if (range1.Item1 >= range2.Item1 && range1.Item2 <= range2.Item2)
				return true;

			return false;
		}

		private bool CheckPartialIntersection(Tuple<int, int> range1, Tuple<int, int> range2)
		{
			return range1.Item1 <= range2.Item2 && range2.Item1 <= range1.Item2;
		}
	}
}

