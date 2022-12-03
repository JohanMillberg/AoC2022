using System;
using System.IO;

namespace AoC2022;

public class DayThree: IDay
{
    public int partOne(string filePath)
    {
        var sumOfPriorities = File.ReadAllText(filePath).Split("\n")
                                                        .Select(r => new List<string>() {
                                                            r.Substring(0, (int)(r.Length / 2)),
                                                            r.Substring((int)(r.Length / 2))
                                                            })
                                                        .Select(l => l[0].Intersect(l[1]))
                                                        .SelectMany(chars => chars.Select(c => priority(c)))
                                                        .Sum();
        return sumOfPriorities;
    }

    public int partTwo(string filePath)
    {
        var sumOfPriorities = File.ReadAllText(filePath).Split("\n")
                                                        .Select((sack, index) => (sack, index))
                                                        .GroupBy(set => set.index / 3)
                                                        .Select(group => group.Aggregate(
                                                            new HashSet<char>(group.First().sack), (set, tup) =>
                                                            {
                                                                set.IntersectWith(tup.sack);
                                                                return set;
                                                            }
                                                        ))
                                                        .SelectMany(chars => chars.Select(c => priority(c)))
                                                        .Sum();

        return sumOfPriorities;
    }

    private static int priority(char ch) => char.IsLower(ch) ? ch - 96 : ch - 38;
}