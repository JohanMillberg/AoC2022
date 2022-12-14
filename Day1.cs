using System;
using System.IO;

namespace AoC2022;

public class DayOne: IDay
{

    public int partOne(string filePath)
    {
        var largestValue = File.ReadAllText(filePath).Split("\n\n").Select(s => s.Split("\n").Select(i => int.Parse(i)).Sum()).Max();
        return largestValue;
    }

    public int partTwo(string filePath)
    {
        var sumOfTopThree = File.ReadAllText(filePath)
                                            .Split("\n\n")
                                            .Select(s => s.Split("\n")
                                            .Select(i => int.Parse(i)).Sum())
                                            .OrderByDescending(i => i)
                                            .Take(3)
                                            .Sum();

        return sumOfTopThree;
    }

}
