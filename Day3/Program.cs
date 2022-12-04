using Day3;

Console.WriteLine("Day 3: Rucksack Reorganization");

string path = @"input.txt";

List<Rucksack> rucksacks = new List<Rucksack>();

Dictionary<int, List<Rucksack>> rucksackGroup = new Dictionary<int, List<Rucksack>>();
int groupCounter = 1;
rucksackGroup.Add(groupCounter, new List<Rucksack>());

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            // Part 1
            var r = new Rucksack(line);
            rucksacks.Add(r);

            // Part 2
            var list = rucksackGroup[groupCounter];
            if (list.Count() == 3)
            {
                list = new List<Rucksack>();
                groupCounter++;
                rucksackGroup.Add(groupCounter, list);
            }
            list.Add(r);
        }
    }
}

// Part 1
var sumOfWrongItemValues = rucksacks.Sum(r => r.WrongItemValue);
Console.WriteLine($"Sum: {sumOfWrongItemValues}");

// Part 2
int commonItemSum = 0;
foreach (List<Rucksack> rucks in rucksackGroup.Values)
{
   char commonItem = Rucksack.SearchCommonInRucksacks(rucks);
   int commonItemValue = Rucksack.GetWrongItemValue(commonItem);
    commonItemSum += commonItemValue;
   Console.WriteLine($"Wrong item: {commonItem}, Value: {commonItemValue}");
}
Console.WriteLine($"Common Sum: {commonItemSum}");

Console.WriteLine("Done");


