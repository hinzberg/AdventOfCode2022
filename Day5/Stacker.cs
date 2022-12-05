using System;
namespace Day5
{
	public class Stacker
	{
        Dictionary<int, List<string>> stacks = new Dictionary<int, List<string>>();

        public Stacker()
        {
            stacks.Add(1, new List<string>());
            stacks.Add(2, new List<string>());
            stacks.Add(3, new List<string>());
            stacks.Add(4, new List<string>());
            stacks.Add(5, new List<string>());
            stacks.Add(6, new List<string>());
            stacks.Add(7, new List<string>());
            stacks.Add(8, new List<string>());
            stacks.Add(9, new List<string>());
        }

        public void Parser(string line)
        {
            List<string> crates = new List<string>();
            crates.Add(line.Substring(0, 3));
            crates.Add(line.Substring(4, 3));
            crates.Add(line.Substring(8, 3));
            crates.Add(line.Substring(12, 3));
            crates.Add(line.Substring(16, 3));
            crates.Add(line.Substring(20, 3));
            crates.Add(line.Substring(24, 3));
            crates.Add(line.Substring(28, 3));
            crates.Add(line.Substring(32, 3));

            for (int index = 1; index <= 9; index++)
            {
                List<string> crs = stacks[index];
                if (!string.IsNullOrEmpty(crates[index-1].Trim()))
                    crs.Insert(0, crates[index - 1].Trim());
            }
        }

        public void PrintStacks()
        {
            for (int i = 1; i <= 9; i++)
            {
                Console.Write($"{i} :");
                foreach (string item in stacks[i])
                    Console.Write($" {item}");
                Console.WriteLine();
            }
        }

        public void PrintTopStacks()
        {
            Console.WriteLine("Top Stacks: ");
            for (int i = 1; i <= 9; i++)
            {
                Console.Write(stacks[i].Last());
            }
        }

        public void ExcecuteInstruction(Instruction instruction)
        {
            List<string> crates = stacks[instruction.FromStack].TakeLast(instruction.Count).ToList();
            //crates.Reverse();
            stacks[instruction.ToStack].AddRange(crates);
            stacks[instruction.FromStack] = stacks[instruction.FromStack].Take(stacks[instruction.FromStack].Count - instruction.Count).ToList();            
        }
    }
}

