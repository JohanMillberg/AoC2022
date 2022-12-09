using System;

namespace AoC2022;

public class DayNine: IDay
{
    public int partOne(string filePath)
    {
        return solve(filePath, 2);
    }

    public int partTwo(string filePath)
    {
        return solve(filePath, 10);
    }

    private int solve(string filePath, int ropeLength)
    {
        var inputCommands = File.ReadAllLines(filePath);
        HashSet<Tuple<int, int>> visitedLocations = new HashSet<Tuple<int, int>>();


        List<Tuple<int, int>> rope = Enumerable.Repeat(new Tuple<int, int>(0, 0), ropeLength).ToList();

        visitedLocations.Add(rope.Last());

        foreach(var command in inputCommands)
        {
            Enum.TryParse(command.Split(" ").First(), out Direction direction);
            int stepAmount = int.Parse(command.Split(" ").Last());
            var resultOfCommand = getNewPositions(direction, stepAmount, rope, ropeLength);

            visitedLocations.UnionWith(resultOfCommand.coordsTailVisited);

            rope = resultOfCommand.rope;
        }

        int result = visitedLocations.Count();
        return result;

    }

    private CommandOutcome getNewPositions(Direction direction, int stepAmount, List<Tuple<int, int>> rope, int ropeLength)
    {
        var directionTuple = getDirectionTuple(direction);
        int xIncrement = directionTuple.Item1;
        int yIncrement = directionTuple.Item2;

        HashSet<Tuple<int, int>> newTailPositions = new HashSet<Tuple<int, int>>();

        for (int i = 0; i < stepAmount; i++)
        {
            rope[0] = new Tuple<int, int>(rope[0].Item1 + xIncrement, rope[0].Item2 + yIncrement);

            for (int j = 1; j < ropeLength; j++)
            {
                if (getChebyshevDistance(rope[j-1], rope[j]) > 1)
                {
                    int tailX = rope[j-1].Item1 - rope[j].Item1;
                    int tailY = rope[j-1].Item2 - rope[j].Item2;

                    rope[j] = new Tuple<int, int>(rope[j].Item1 + Math.Sign(tailX), rope[j].Item2 + Math.Sign(tailY));
                }
            }
            newTailPositions.Add(rope.Last());
        }

        var currentHeadPosition = rope[0];
        var currentTailPosition = rope[ropeLength-1];

        return new CommandOutcome(newTailPositions, rope);
    }

    private Tuple<int, int> getDirectionTuple(Direction direction) =>
        direction switch
            {
                Direction.U => new Tuple<int, int>(0, 1),
                Direction.R => new Tuple<int, int>(1, 0),
                Direction.D => new Tuple<int, int>(0, -1),
                Direction.L => new Tuple<int, int>(-1, 0),
                _ => throw new ArgumentException()
            };

    private int getChebyshevDistance(Tuple<int, int> point1, Tuple<int, int> point2) =>
        Math.Max(Math.Abs(point2.Item1 - point1.Item1), Math.Abs(point2.Item2 - point1.Item2));

}

public enum Direction
{
    U,
    R,
    D,
    L 
}

public record CommandOutcome(HashSet<Tuple<int, int>> coordsTailVisited, List<Tuple<int, int>> rope);