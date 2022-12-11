using System;
namespace Day8
{
	public class Tree
	{
		public int LocationX { get; set; }
		public int LocationY { get; set; }
		public int Height { get; set; }
		public bool IsVisible { get; set; }
		public List<int> ScenicScores { get; set; }
		public int ScenicScoreTotal { get; set; }

        public Tree()
		{
			LocationX = 0;
			LocationY = 0;
			Height = 0;
			IsVisible = false;
			ScenicScores = new List<int>();
            ScenicScoreTotal = 1;
        }

		public void CalculateScenicScoreTotal()
		{
			foreach (var score in ScenicScores)
			{
				ScenicScoreTotal *= score;
			}
		}
	}
}

