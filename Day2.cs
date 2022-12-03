using System;
using System.IO;

namespace AoC2022;

public class DayTwo: IDay
{
    public int partOne(string filePath)    
    {
        var totalScore = File.ReadAllText(filePath).Split("\n").Select(i => calculateScore(i.Split(" ")[0], i.Split(" ")[1])).Sum();
        return totalScore;
    }

    public int partTwo(string filePath)
    {
        var totalScore = File.ReadAllText(filePath).Split("\n").Select(i => calculateScoreTwo(i.Split(" ")[0], i.Split(" ")[1])).Sum();
        return totalScore;
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

    private static int calculateScoreTwo(string firstMove, string gameResult)
    {
        return firstMove switch
        {
            "A" => gameResult switch {
                "X" => 3,
                "Y" => 4,
                "Z" => 8
            },

            "B" => gameResult switch {
                "X" => 1,
                "Y" => 5,
                "Z" => 9
            },

            "C" => gameResult switch {
                "X" => 2,
                "Y" => 6,
                "Z" => 7
            }
        };
    }
}