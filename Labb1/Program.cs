using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Drawing;


PrintMatches("29535123p48723487597645723645");

void PrintMatches(string text)
{
    long sum = 0;

    for (int i = 0; i < text.Length; i++)
    {

        if (i == text.Length) break;

        if (!char.IsDigit(text[i])) continue;

        Match nextMatch = FindNextMatch(i, text);

        if (nextMatch is not null)
        {
            PrintCharathers(nextMatch, text);
            sum = sum + nextMatch.Value;
            Console.WriteLine();
        }
    }
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"total value is:{sum}");
}

bool InMatchRange(int index, Match match)
{
    return match.StartPos <= index && index <= match.StartPos + match.EndPos;
}

Match FindNextMatch(int index, string text)
{
    for (int i = index + 1; i < text.Length; i++)
    {
        int matchLength = Math.Abs(index - i) + 1;
        string match = text.Substring(index, matchLength);

        if (text[index] == text[i] && match.All(char.IsDigit))
        {
            return new Match() { StartPos = index, EndPos = matchLength - 1, Value = long.Parse(match) };
        }
    }

    return null;
}

void PrintCharathers(Match match, string text)
{
    for (int i = 0; i < text.Length; i++)
    {
        if (InMatchRange(i, match))
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.Write(text[i]);
    }
}


class Match
{
    public int StartPos { get; set; }
    public int EndPos { get; set; }
    public long Value { get; set; }
}