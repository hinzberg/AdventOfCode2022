using System;
namespace Day2
{
	public enum Selection {  Rock, Paper, Scissors }

	public class GameRound
	{
        public Selection ElfSelection { get; set; }
        public Selection PlayerSelection { get; set; }
        public string ElfValue { get; set; }
        public string PlayerValue { get; set; }

        public GameRound(string elf, string player)
		{
            ElfValue = elf;
            PlayerValue = player;

			if (elf == "A")
				ElfSelection = Selection.Rock;
            else if (elf == "B")
                ElfSelection = Selection.Paper;
            else if (elf == "C")
                ElfSelection = Selection.Scissors;
            else
            {
                Console.WriteLine("Invalid");
            }

            if (player == "X")
                PlayerSelection = Selection.Rock;
            else if (player == "Y")
                PlayerSelection = Selection.Paper;
            else if (player == "Z")
                PlayerSelection = Selection.Scissors;
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

