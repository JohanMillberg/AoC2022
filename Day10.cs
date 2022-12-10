using System;

namespace AoC2022;

public class DayTen: IDay
{
    public int partOne(string filePath)
    {
        var checkPoints = new List<int>() {
            20, 60, 100, 140, 180, 220
        };

        int result = processInput(filePath, checkPoints);

        return result;
    }

    public int partTwo(string filePath)
    {
        drawResults(filePath);
        return 1;
    }

    private int processInput(string filePath, List<int> checkPoints)
    {
        int register = 1;
        int clockCycle = 0;

        List<int> resultList = new List<int>();

        var commands = File.ReadAllLines(filePath);
        foreach (var command in commands)
        {
            var commandParts = command.Split(" ");
            Enum.TryParse(commandParts.First(), out OperationType operation);

            if (operation == OperationType.noop)
            {
                clockCycle++;
                if (checkPoints.Contains(clockCycle))
                {
                    resultList.Add(register * clockCycle);
                }
            }
            else if (operation == OperationType.addx)
            {
                clockCycle++;
                if (checkPoints.Contains(clockCycle))
                {
                    resultList.Add(register * clockCycle);
                }

                clockCycle++;
                if (checkPoints.Contains(clockCycle))
                {
                    resultList.Add(register * clockCycle);
                }
                register += int.Parse(commandParts.Last());
            }
        }
        
        return resultList.Sum();
    }

    private void drawResults(string filePath)
    {
        int register = 1;
        int clockCycle = 0;

        var commands = File.ReadAllLines(filePath);
        foreach (var command in commands)
        {
            var commandParts = command.Split(" ");
            Enum.TryParse(commandParts.First(), out OperationType operation);

            if (operation == OperationType.noop)
            {
                clockCycle++;
                drawPixel(register, clockCycle);
            }
            else if (operation == OperationType.addx)
            {
                clockCycle++;
                drawPixel(register, clockCycle);
                clockCycle++;
                drawPixel(register, clockCycle);
                register += int.Parse(commandParts.Last());
            }
        }
    }

    private void drawPixel(int register, int clockCycle)
    {
        if (Enumerable.Range(register % 40, 3).Contains(clockCycle % 40))
        {
            Console.Write("#");
        }
        else
        {
            Console.Write(".");
        }

        if (clockCycle % 40 == 0)
        {
            Console.WriteLine();
        }

    }

}

internal enum OperationType
{
    addx,
    noop
}