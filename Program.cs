namespace AoC2022;

public class ControllerClass
{
    public static void runDayOne()
    {
        int resultOne = DayOne.partOne("input/day1.txt");
        Console.WriteLine(String.Format("The elf that carries the most calories carries: {0},", resultOne));

        int resultTwo = DayOne.partTwo("input/day1.txt");
        Console.WriteLine(String.Format("The top three elfs carry: {0},", resultTwo));

    }


    public static void Main()
    {
        runDayOne();
    }
}