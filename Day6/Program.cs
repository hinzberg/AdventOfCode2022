using Day6;

Console.WriteLine("Day 6: Tuning Trouble");

/*
Signal sig1 = new Signal("bvwbjplbgvbhsrlpgdmjqwftvncz");
Console.WriteLine($"Start of Packet: {sig1.FindStartOfPacketMarker()}");
Signal sig2 = new Signal("nppdvjthqldpwncqszvftbrmjlhg");
Console.WriteLine($"Start of Packet: {sig2.FindStartOfPacketMarker()}");
Signal sig3 = new Signal("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
Console.WriteLine($"Start of Packet: {sig3.FindStartOfPacketMarker()}");
Signal sig4 = new Signal("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
Console.WriteLine($"Start of Packet: {sig4.FindStartOfPacketMarker()}");

Signal sig5 = new Signal("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
Console.WriteLine($"Start of Message: {sig5.FindStartOfMessage()}");
Signal sig6 = new Signal("bvwbjplbgvbhsrlpgdmjqwftvncz");
Console.WriteLine($"Start of Message: {sig6.FindStartOfMessage()}");
Signal sig7 = new Signal("nppdvjthqldpwncqszvftbrmjlhg");
Console.WriteLine($"Start of Message: {sig7.FindStartOfMessage()}");
Signal sig8 = new Signal("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
Console.WriteLine($"Start of Message: {sig8.FindStartOfMessage()}");
Signal sig9 = new Signal("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
Console.WriteLine($"Start of Message: {sig9.FindStartOfMessage()}");
*/

string path = @"input.txt";
string content = string.Empty;

using (StreamReader sr = new StreamReader(path))
{
    while (sr.Peek() != -1)
    {
        var line = sr.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
           content += line;
        }
    }
}

Console.WriteLine(content);
Signal signal = new Signal(content);
Console.WriteLine($"Start of Packet: {signal.FindStartOfPacketMarker()}");
Console.WriteLine($"Start of Message: {signal.FindStartOfMessage()}");

Console.WriteLine("Done");