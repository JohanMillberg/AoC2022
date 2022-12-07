namespace AoC2022;

public interface IDay
{
    public int partOne(string filepath);

    public int partTwo(string filePath);
};
public interface IDayString
{
    public string partOne(string filepath);

    public string partTwo(string filePath);
};

public class ControllerClass
{
    public static void runDay(IDay dayController, string filePath)
    {
        Console.WriteLine($"The result of {filePath.Split("/")[1].Split(".")[0]}");

        int resultOne = dayController.partOne(filePath);
        Console.WriteLine($"The result of part one is: {resultOne}");

        int resultTwo = dayController.partTwo(filePath);
        Console.WriteLine($"The result of part two is: {resultTwo}\n");
    }

    public static void runDayString(IDayString dayController, string filePath)
    {
        Console.WriteLine($"The result of {filePath.Split("/")[1].Split(".")[0]}");

        string resultOne = dayController.partOne(filePath);
        Console.WriteLine($"The result of part one is: {resultOne}");

        string resultTwo = dayController.partTwo(filePath);
        Console.WriteLine($"The result of part two is: {resultTwo}\n");
    }

    public static void Main()
    {
        runDay(new DayOne(), "Input/day1.txt");
        runDay(new DayTwo(), "Input/day2.txt");
        runDay(new DayThree(), "Input/day3.txt");
        runDay(new DayFour(), "Input/day4.txt");
        runDayString(new DayFive(), "Input/day5.txt");
        runDay(new DaySix(), "Input/day6.txt");
        runDay(new DaySeven(), "Input/day7.txt");
    }
}