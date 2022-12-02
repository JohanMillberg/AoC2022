namespace AoC2022;

public class ControllerClass
{
    public static void runDayOne()
    {
        int resultOne = DayOne.partOne("Input/day1.txt");
        Console.WriteLine(String.Format("The elf that carries the most calories carries: {0},", resultOne));

        int resultTwo = DayOne.partTwo("Input/day1.txt");
        Console.WriteLine(String.Format("The top three elfs carry: {0},", resultTwo));

    }

    public static void runDayTwo()
    {
        int resultOne = DayTwo.partOne("Input/day2.txt");
        Console.WriteLine($"Total score: {resultOne}");

        int resultTwo = DayTwo.partTwo("Input/day2.txt");
        Console.WriteLine($"Total score: {resultTwo}");
    }

    public static void Main()
    {
        // runDayOne();
        runDayTwo();
    }
}