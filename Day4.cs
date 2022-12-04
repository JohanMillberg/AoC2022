using System;

namespace AoC2022;

public class DayFour: IDay
{
    public int partOne(string filePath)
    {
        var overlappingPairs = File.ReadAllText(filePath)
                                               .Split("\n")
                                               .Select(pair => new List<IEnumerable<int>>(){
                                                    Enumerable.Range(
                                                        int.Parse(pair.Split(",")[0].Split("-")[0]),
                                                        int.Parse(pair.Split(",")[0].Split("-")[1])
                                                        - int.Parse(pair.Split(",")[0].Split("-")[0])+1

                                                    ),
                                                    Enumerable.Range(
                                                        int.Parse(pair.Split(",")[1].Split("-")[0]),
                                                        int.Parse(pair.Split(",")[1].Split("-")[1])
                                                        - int.Parse(pair.Split(",")[1].Split("-")[0])+1
                                                    )
                                                })
                                               .Select(group => 
                                                            group.First().All(i=>group.First()
                                                                 .Intersect(group.Last()).Contains(i))
                                                                 ||
                                                            group.Last().All(i=>group.First()
                                                                 .Intersect(group.Last()).Contains(i))
                                                )
                                               .Select(i => Convert.ToInt32(i))
                                               .Sum();

        return overlappingPairs;
    }

    public int partTwo(string filePath)
    {
        var overlappingPairs = File.ReadAllText(filePath)
                                               .Split("\n")
                                               .Select(pair => new List<IEnumerable<int>>(){
                                                    Enumerable.Range(
                                                        int.Parse(pair.Split(",")[0].Split("-")[0]),
                                                        int.Parse(pair.Split(",")[0].Split("-")[1])
                                                        - int.Parse(pair.Split(",")[0].Split("-")[0])+1

                                                    ),
                                                    Enumerable.Range(
                                                        int.Parse(pair.Split(",")[1].Split("-")[0]),
                                                        int.Parse(pair.Split(",")[1].Split("-")[1])
                                                        - int.Parse(pair.Split(",")[1].Split("-")[0])+1
                                                    )
                                                })
                                               .Select(group => 
                                                            group.First().Any(i=>group.First()
                                                                 .Intersect(group.Last()).Contains(i))
                                                                 ||
                                                            group.Last().Any(i=>group.First()
                                                                 .Intersect(group.Last()).Contains(i))
                                                )
                                               .Select(i => Convert.ToInt32(i))
                                               .Sum();

        return overlappingPairs;
    }
}