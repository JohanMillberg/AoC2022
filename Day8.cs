using System;

namespace AoC2022;

public class DayEight: IDay
{
    public int partOne(string filePath)
    {
        var result = File.ReadAllText(filePath).Split("\r\n")
                                               .SelectMany((l, i) => l.Split()
                                                                      .Select(s => new int[] {i, int.Parse(i.ToString())})
                                                                      .ToArray());
        // foreach column
        return 1;
    }

    public int partTwo(string filePath)
    {
        return 1;
    }


    private int countVisibleTrees(int[] line)
    {
        return 1;
    }

}