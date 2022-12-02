using System;
using System.IO;

namespace AoC2022;

public static class DayTwo
{
    public static int partOne(string filePath)    
    {
        var totalScore = File.ReadAllText(filePath).Split("\r\n").Select(i => calculateScore(i.Split(" ")[0], i.Split(" ")[1]));
    }

    private static int calculateScore(string firstMove, string secondMove)
    {
        return firstMove switch
        {
            "A" => secondMove switch {
                "X" => 4,
                "Y" => 8,
                "Z" => 3
            },

            "B" => secondMove switch {
                "X" => 1,
                "Y" => 5,
                "Z" => 9
            },

            "C" => secondMove switch {
                "X" => 7,
                "Y" => 2,
                "Z" => 6
            }
        };
    }
}