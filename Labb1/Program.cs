// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;


PrintMatches("29535123p48723487597645723645");

void PrintMatches(string originalText)
{
    long sum = 0;
    NextMatch();

    void NextMatch(int index = 0)
    {

        if (index == originalText.Length) return;

        string text = originalText.Substring(index);

        var firstChar = text.First();

        string pattern = @$"^([{firstChar}])\d*?\1";
        Regex rg = new Regex(pattern);

        if (rg.IsMatch(text) && Char.IsDigit(firstChar))
        {
            var match = rg.Matches(text).FirstOrDefault();

            sum = sum + long.Parse(match!.Value);

            for (int i = 0; i < originalText.Length; i++)
            {

                if(i < index || index + match.Length <= i)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(originalText[i]);

            }
            Console.WriteLine();
        }
        NextMatch(index + 1);
    }
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"total value is:{sum}");
}
