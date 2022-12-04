using System;
namespace Day3
{
	public class Rucksack
	{
		public string Content { get; set; }
        public string Compartment1 { get; set; }
        public string Compartment2 { get; set; }
		public char WrongItem { get; set; }
        public int WrongItemValue { get; set; }

        public Rucksack(string input)
		{
			Content = input;
			int compartmentSize = input.Length / 2;
			Compartment1 = input.Substring(0,compartmentSize);
			Compartment2 = input.Substring(compartmentSize, compartmentSize);
			WrongItem = FindWrongItem(Compartment1, Compartment2);
			WrongItemValue = GetWrongItemValue(WrongItem);
            // Console.WriteLine($"Wrong item: {WrongItem}, Value: {WrongItemValue}");
        }

		public static char FindWrongItem(string compartment1, string compartment2)
		{
			char[] comp1 = compartment1.ToCharArray();
            char[] comp2 = compartment2.ToCharArray();

			foreach (char c in comp2)
			{
				if (comp1.Contains(c))
					return c;
			}

            foreach (char c in comp1)
            {
                if (comp2.Contains(c))
                    return c;
            }
			return ' ';
		}

		public static int GetWrongItemValue(char item)
		{
			int returnValue = 0;
			int characterValue = (int)item;
			if (characterValue >= 65 && characterValue <= 90) // A-Z, 65-90
			{
                returnValue = characterValue - 38;
            }
            else if (characterValue >= 97 && characterValue <= 122) // a-z, 97-122
            {
				returnValue = characterValue - 96;
            }
			else
			{

			}
			return returnValue;
		}

		public static char SearchCommonInRucksacks(List<Rucksack> rucksacks)
		{
			if (rucksacks.Count() == 3)
			{
                var commons = rucksacks[0].Content.ToCharArray().Intersect(rucksacks[1].Content.ToCharArray());
                commons = commons.Intersect(rucksacks[2].Content.ToCharArray());
				return commons.First();
            }
            return ' ';
        }
    }
}

