using System;
using System.Text.RegularExpressions;

namespace AoC2022;

public class DaySix: IDay
{
    public int partOne(string filePath)
    {
        SignalParser parser = new SignalParser(filePath);
        int packetEnd = parser.findPacket(4);
        
        return packetEnd;
    }

    public int partTwo(string filePath)
    {
        SignalParser parser = new SignalParser(filePath);
        int packetEnd = parser.findPacket(14);
        
        return packetEnd;
    }
}

public class SignalParser
{
    string signal {get; set;}
    public SignalParser(string filePath)
    {
        signal = File.ReadAllText(filePath);
    }

    public int findPacket(int messageLength)
    {
        for (int i = 0; i < this.signal.Length - messageLength; i++)
        {
            string currentString = this.signal.Substring(i, messageLength);
            bool isUnique = Regex.IsMatch(currentString, @"^(?:([A-Za-z])(?!.*\1))*$");

            if (isUnique)
            {
                return i+messageLength;
            }
        }

        return 0;
    }
}