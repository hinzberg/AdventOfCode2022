using System;
namespace Day2
{
	public class Game
	{
        public int ElfScore = 0;
        public int PlayerScore = 0;

        public Game()
        {
        }

        public void AdjustSelectionForGame2(List<GameRound> rounds)
        {
            foreach (GameRound round in rounds)
            {
                if (round.PlayerValue == "Y")
                {
                    Console.WriteLine("Must be draw");
                    round.PlayerSelection = round.ElfSelection;
                }
                else if (round.PlayerValue == "X")
                {
                    Console.WriteLine("Player needs to loose");
                    round.PlayerSelection = GetLoosingSelection(round.ElfSelection);
                }
                else if (round.PlayerValue == "Z")
                {
                    Console.WriteLine("Player needs to win");
                    round.PlayerSelection = GetWinningSelection(round.ElfSelection);
                }
            }
        }

        public void PlayGame(List<GameRound> rounds)
		{
            foreach (GameRound round in rounds)
            {
                ElfScore += ScoreForSelection(round.ElfSelection);
                PlayerScore += ScoreForSelection(round.PlayerSelection);

                if (round.ElfSelection == round.PlayerSelection)
                {
                    Console.WriteLine("Draw");
                    ElfScore += 3;
                    PlayerScore += 3;
                }
                else if (round.ElfSelection == Selection.Rock && round.PlayerSelection == Selection.Scissors)
                {
                    Console.WriteLine("Elf wins with Rock ober Scissor");
                    ElfScore += 6;
                }
                else if (round.ElfSelection == Selection.Scissors && round.PlayerSelection == Selection.Paper)
                {
                    Console.WriteLine("Elf wins with Scissors over Paper");
                    ElfScore += 6;
                }
                else if (round.ElfSelection == Selection.Paper && round.PlayerSelection == Selection.Rock)
                {
                    Console.WriteLine("Elf wins with Paper over Rock");
                    ElfScore += 6;
                }

                else if (round.PlayerSelection == Selection.Scissors && round.ElfSelection == Selection.Paper)
                {
                    Console.WriteLine("Player wins with Scissors over Paper");
                    PlayerScore += 6;
                }
                else if (round.PlayerSelection == Selection.Rock && round.ElfSelection == Selection.Scissors)
                {
                    Console.WriteLine("Player wins with Rock over Scissor");
                    PlayerScore += 6;
                }
                else if (round.PlayerSelection == Selection.Paper && round.ElfSelection == Selection.Rock)
                {
                    Console.WriteLine("Player wins with Paper over Rock");
                    PlayerScore += 6;
                }

                else
                {
                    Console.WriteLine("Unknown");
                }
            }
        }

        public int ScoreForSelection(Selection selection)
        {
            if (selection == Selection.Rock)
                return 1;

            if (selection == Selection.Paper)
                return 2;

            if (selection == Selection.Scissors)
                return 3;

            return 0;
        }

        public Selection GetWinningSelection(Selection oponentSelection)
        {
            if (oponentSelection == Selection.Rock)
                return Selection.Paper;
            if (oponentSelection == Selection.Paper)
                return Selection.Scissors;
            // if (oponentSelection == Selection.Scissors)
                return Selection.Rock;
        }

        public Selection GetLoosingSelection(Selection oponentSelection)
        {
            if (oponentSelection == Selection.Rock)
                return Selection.Scissors;
            if (oponentSelection == Selection.Paper)
                return Selection.Rock;
            // if (oponentSelection == Selection.Scissors)
            return Selection.Paper;
        }
    }
}

