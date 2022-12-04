using Day4;

Console.WriteLine("Day 4: Camp Cleanup");

string path = @"input.txt";

List<CleanupPair> pairs = new List<CleanupPair>();

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            var p = new CleanupPair(line);
            pairs.Add(p);
        }
    }
}

var completeIntersectCount = pairs.Count(a => a.DoesCompleteIntersect);
Console.WriteLine($"Complete Intersect Count: {completeIntersectCount}");

var partialntersectCount = pairs.Count(a => a.DoesPartialIntersect);
Console.WriteLine($"Partial Intersect Count: {partialntersectCount}");

Console.WriteLine("Done");

