using System;

namespace AoC2022;

public class DayEight: IDay
{
    public int partOne(string filePath)
    {
        int[][] inputMatrix = File.ReadAllText(filePath).Split("\n")
                                                        .Select(l => l.ToArray()
                                                        .Select(num => int.Parse(num.ToString()))
                                                        .ToArray())
                                                        .ToArray();


        List<Tuple<int, int>> coordTuples = new List<Tuple<int, int>>();
        for (int i = 0; i < inputMatrix[0].Length; i++)
        {
            for (int j = 0; j < inputMatrix.Length; j++)
            {
                coordTuples.Add(new Tuple<int, int>(i, j));
            }
        }
        
        int result = 0;

        foreach (var coords in coordTuples)
        {
            result += isVisible(inputMatrix, coords.Item1, coords.Item2) ? 1 : 0;
        }

        return result;
    }

    public int partTwo(string filePath)
    {
        int[][] inputMatrix = File.ReadAllText(filePath).Split("\n")
                                                        .Select(l => l.ToArray()
                                                        .Select(num => int.Parse(num.ToString()))
                                                        .ToArray())
                                                        .ToArray();


        List<Tuple<int, int>> coordTuples = new List<Tuple<int, int>>();
        for (int i = 0; i < inputMatrix[0].Length; i++)
        {
            for (int j = 0; j < inputMatrix.Length; j++)
            {
                coordTuples.Add(new Tuple<int, int>(i, j));
            }
        }
        
        int result = 0;

        foreach (var coords in coordTuples)
        {
            result = Math.Max(result, calculateScenicScore(inputMatrix, coords.Item1, coords.Item2));
        }


        return result;
    }

    private bool isVisible(int[][] matrix, int x, int y)
    {
        bool visibleFromLeft = Enumerable.Range(0, x+1).Select(i => matrix[i][y]).Reverse().Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromTop = Enumerable.Range(0, y+1).Select(i => matrix[x][i]).Reverse().Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromRight = Enumerable.Range(x, matrix.Length - x).Select(i => matrix[i][y]).Skip(1).All(n => n < matrix[x][y]);
        bool visibleFromBot = Enumerable.Range(y, matrix[0].Length - y).Select(i => matrix[x][i]).Skip(1).All(n => n < matrix[x][y]);

        return visibleFromBot || visibleFromLeft || visibleFromRight || visibleFromTop;
    }

    private int calculateScenicScore(int[][] matrix, int x, int y)
    {
        int result = Enumerable.Range(0, x + 1).Select(i => matrix[i][y]).Reverse().Skip(1).TakeWhile(t => t < matrix[x][y], true).Count() *
            Enumerable.Range(0, y + 1).Select(i => matrix[x][i]).Reverse().Skip(1).TakeWhile(t => t < matrix[x][y], true).Count() * 
            Enumerable.Range(x, matrix.Length - x).Select(i => matrix[i][y]).Skip(1).TakeWhile(t => t < matrix[x][y], true).Count() * 
            Enumerable.Range(y, matrix[0].Length - y).Select(i => matrix[x][i]).Skip(1).TakeWhile(i => i < matrix[x][y], true).Count();

        return result;
    }
}

public static class LinqExtensions
{
    public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> compareFunc, bool inclusive)
    {
        foreach (T item in source)
        {
            if (compareFunc(item))
            {
                yield return item;
            }
            else
            {
                if (inclusive)
                {
                    yield return item;
                } 
                yield break;
            }
        }
    }
}