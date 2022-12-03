using System;
using System.IO;

namespace AoC2022;

public class DayThree: IDay
{
    public int partOne(string filePath)
    {
        var rucksacks = File.ReadAllText(filePath).Split("\n");
        Console.WriteLine(rucksacks.Count());
        return 1;
    }

    public int partTwo(string filePath)
    {
        return 1;
    }
}