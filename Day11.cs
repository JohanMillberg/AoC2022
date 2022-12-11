using System;

namespace AoC2022;

public class DayEleven: IDay
{
    public int partOne(string filePath)
    {
        var monkeys = File.ReadAllText(filePath).Split("\n\n")
                                                .Select(m => m.Split("\n")
                                                .Select(line =>
                                                line.Contains("Monkey") ? "0" :
                                                line.Contains("Starting items:") ? line.Split(":")[1].Trim() :
                                                line.Contains("Operation:") ? line.Split("=")[1] :
                                                line.Contains("Test:") ? line.Split(" ").Last().Trim() :
                                                line.Contains("If") ? line.Split("monkey")[1].Trim() : "").ToArray()
                                                ).ToArray();

        var mods = monkeys.Select(m => int.Parse(m[3])).Aggregate(1, (x, y) => x*y);
        long Eval(string expression) => Convert.ToInt64(new System.Data.DataTable().Compute(expression, ""));

        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey[1].Split(",").Where(x => x != ""))
                {
                    var newLevel = Eval($"{monkey[2].Replace("old", $"{item}.0")}");
                    //newLevel %= mods;
                    newLevel /= 3;

                    if (newLevel % int.Parse(monkey[3]) == 0)
                    {
                        monkeys[int.Parse(monkey[4])][1] += $",{newLevel}";
                    }
                    else
                    {
                        monkeys[int.Parse(monkey[5])][1] += $",{newLevel}";
                    }

                    monkey[0] = (int.Parse(monkey[0]) + 1).ToString();
                }
                monkey[1] = "";
            }

        }

        var result = monkeys.Select(m => long.Parse(m[0])).OrderByDescending(x => x).ToArray();

        Console.WriteLine(result[0] * result[1]);
        return 1;
    }

    public int partTwo(string filePath)
    {
        var monkeys = File.ReadAllText(filePath).Split("\n\n")
                                                .Select(m => m.Split("\n")
                                                .Select(line =>
                                                line.Contains("Monkey") ? "0" :
                                                line.Contains("Starting items:") ? line.Split(":")[1].Trim() :
                                                line.Contains("Operation:") ? line.Split("=")[1] :
                                                line.Contains("Test:") ? line.Split(" ").Last().Trim() :
                                                line.Contains("If") ? line.Split("monkey")[1].Trim() : "").ToArray()
                                                ).ToArray();

        var mods = monkeys.Select(m => int.Parse(m[3])).Aggregate(1, (x, y) => x*y);
        long Eval(string expression) => Convert.ToInt64(new System.Data.DataTable().Compute(expression, ""));

        for (int i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey[1].Split(",").Where(x => x != ""))
                {
                    var newLevel = Eval($"{monkey[2].Replace("old", $"{item}.0")}");
                    newLevel %= mods;

                    if (newLevel % int.Parse(monkey[3]) == 0)
                    {
                        monkeys[int.Parse(monkey[4])][1] += $",{newLevel}";
                    }
                    else
                    {
                        monkeys[int.Parse(monkey[5])][1] += $",{newLevel}";
                    }

                    monkey[0] = (int.Parse(monkey[0]) + 1).ToString();
                }
                monkey[1] = "";
            }

        }

        var result = monkeys.Select(m => long.Parse(m[0])).OrderByDescending(x => x).ToArray();

        Console.WriteLine(result[0] * result[1]);
        return 1;
    }

}