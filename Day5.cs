using System;
using System.Text.RegularExpressions;

namespace AoC2022;

public class DayFive: IDayString 
{
    private record Move(int amountBoxes, Stack<char> source, Stack<char> destination);

    public string partOne(string filePath)
    {
        string result = moveCrates(filePath, crateMover);
        return result;
    }

    public string partTwo(string filePath)
    {
        string result = moveCrates(filePath, crateMoverTwo);
        return result;
    }

    private void crateMover(Move move)
    {
        for (int i = 0; i < move.amountBoxes; i++)
        {
            move.destination.Push(move.source.Pop());
        }
    }

    private void crateMoverTwo(Move move)
    {
        var orderStack = new Stack<char>();
        crateMover(move with {destination = orderStack});
        crateMover(move with {source = orderStack});
    }

    private string moveCrates(string filePath, Action<Move> mover)
    {
        var sections = File.ReadAllText(filePath).Split("\n\n");
        var stackRows = sections[0].Split("\n");

        var stacks = stackRows.Last().Chunk(4)
                                     .Select(_ => new Stack<char>()).ToArray();

        foreach (var row in stackRows.Reverse().Skip(1))
        {
            foreach (var (stack, item) in stacks.Zip(row.Chunk(4)))
            {
                if (item[1] != ' ')
                {
                    stack.Push(item[1]);
                }
            }
        }

        var moveDescriptions = sections[1].Split("\n");

        foreach (var action in moveDescriptions)
        {
            var spec = Regex.Match(action, @"move (\d+) from (\d+) to (\d+)");
            int amountOfMovements = int.Parse(spec.Groups[1].Value);
            int source = int.Parse(spec.Groups[2].Value) - 1;
            int destination = int.Parse(spec.Groups[3].Value) -1;
            mover(new Move(amountOfMovements, stacks[source], stacks[destination]));
        }

        return string.Join("", stacks.Select(stack => stack.Pop()));
    }
}