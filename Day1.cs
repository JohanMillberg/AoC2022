using System;
using System.IO;

namespace AoC2022;

public static class DayOne
{

    public static int partOne(string filePath)
    {
        var largestValue = File.ReadAllText(filePath).Split("\r\n\r\n").Select(s => s.Split("\r\n").Select(i => int.Parse(i)).Sum()).Max();
        return largestValue;
    }

    public static int partTwo(string filePath)
    {
        var sumOfTopThree = File.ReadAllText(filePath)
                                            .Split("\r\n\r\n")
                                            .Select(s => s.Split("\r\n")
                                            .Select(i => int.Parse(i)).Sum())
                                            .OrderByDescending(i => i)
                                            .Take(3)
                                            .Sum();

        return sumOfTopThree;
    }

}
