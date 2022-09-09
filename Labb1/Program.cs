using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


PrintMatches("29535123p48723487597645723645");

void PrintMatches(string text)
{
    long sum = 0;

    for (int index = 0; index < text.Length; index++)
    {

        if (index == text.Length) break;

        if (!char.IsDigit(text[index])) continue;

        string match = FindNextMatch(index, text);

        if (!string.IsNullOrEmpty(match))
        {

            PrintCharathers(index, match.Length, text);

            sum = sum + long.Parse(match);
            Console.WriteLine();
        }
    }
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"total value is:{sum}");
}

bool IsInRange(int i, int index, int matchLength)
{
    return i < index || index + matchLength <= i;
}

string FindNextMatch(int start, string text)
{
    for (int end = 1 + start; end < text.Length; end++)
    {
        string match = text.Substring(start, Math.Abs(start - end) + 1);

        if (text[start] == text[end] && match.All(char.IsDigit))
        {
            return match;
        }
    }

    return String.Empty;
}

void PrintCharathers(int start, int matchLength, string text)
{
    for (int i = 0; i < text.Length; i++)
    {
        if (IsInRange(i, start, matchLength))
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write(text[i]);
    }
}


