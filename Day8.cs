using System;

namespace AoC2022;

public class DayEight: IDay
{
    public int partOne(string filePath)
    {
        int[][] inputMatrix = File.ReadAllText(filePath).Split("\r\n")
                                                        .Select(l => l.ToArray()
                                                        .Select(num => int.Parse(num.ToString()))
                                                        .ToArray())
                                                        .ToArray();

        var coords = Enumerable.Range(0, inputMatrix[0].Length).Select(x => {x, })
        foreach (var coords in Enumerable.Range(0, inputMatrix[0].Lengt)

        // foreach column
        return 1;
    }

    public int partTwo(string filePath)
    {
        return 1;
    }

    private bool isVisible(int[][] matrix, int x, int y)
    {
        bool visibleFromLeft = Enumerable.Range(0, x+1).Select(i => matrix[i][y]).Reverse().Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromTop = Enumerable.Range(0, y+1).Select(i => matrix[x][i]).Reverse().Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromRight = Enumerable.Range(x, matrix[0].Length - x).Select(i => matrix[i][y]).Reverse().Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromBot = Enumerable.Range(y, matrix[0].Length - y).Select(i => matrix[x][i]).Reverse().Skip(1).All(n => n < matrix[x][y]);

        return visibleFromBot || visibleFromLeft || visibleFromRight || visibleFromTop;
    }

}