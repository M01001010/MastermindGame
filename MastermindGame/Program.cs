using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static readonly char[] ValidInputs = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
    private static string secretCode = "";
    private static int maxAttempts = 10;


    static void Main(string[] args)
    {
        ParseArguments(args);
        GameLoop();
    }


    private static void ParseArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-c" && i + 1 < args.Length)
            {
                secretCode = args[i + 1];
                if (!IsValidCode(secretCode))
                {
                    Console.WriteLine("Invalid secret code provided. Generating random code instead.");
                    secretCode = GenerateRandomCode();
                }
                i++;
            }
            else if (args[i] == "-t" && i + 1 < args.Length)
            {
                if (int.TryParse(args[i + 1], out int attempts) && attempts > 0)
                {
                    maxAttempts = attempts;
                }
                i++;
            }
        }
    }


    private static bool IsValidCode(string code)
    {
        if (code.Length != 4) return false;
        if (code.Distinct().Count() != 4) return false;
        return code.All(x => ValidInputs.Contains(x));
    }


    private static string GenerateRandomCode()
    {
        Random random = new Random();
        var shuffled = ValidInputs.OrderBy(x => random.Next()).Take(4).ToArray();
        return new string(shuffled);
    }


    private static void GameLoop()
    {
        Console.WriteLine("Will you find the secret code?");
        Console.WriteLine("Please enter a valid guess (4 distinct digits from 0-8)");

        int attemptsLeft = maxAttempts;

        while (attemptsLeft > 0)
        {
            Console.Write($"\nRound {maxAttempts - attemptsLeft + 1}/{maxAttempts} > ");
            string? input = Console.ReadLine();

            // Handle (EOF)
            if (input == null)
            {
                Console.WriteLine("\nGame ended by user.");
                return;
            }

            input = input.Trim();

            if (!IsValidCode(input))
            {
                Console.WriteLine("Wrong input! Please enter 4 distinct digits from 0-8.");
                continue;
            }

            if (input == secretCode)
            {
                Console.WriteLine("Congratz! You did it!");
                return;
            }

            EvaluateGuess(input, out int wellPlaced, out int misplaced);
            Console.WriteLine($"Well-placed pieces: {wellPlaced}");
            Console.WriteLine($"Misplaced pieces: {misplaced}");

            attemptsLeft--;
        }

        Console.WriteLine($"\nGame over! The secret code was: {secretCode}.");
    }


    private static void EvaluateGuess(string guess, out int wellPlaced, out int misplaced)
    {
        wellPlaced = 0;
        misplaced = 0;

        for (int i = 0; i < 4; i++)
        {
            if (guess[i] == secretCode[i])
            {
                wellPlaced++;
            }
            else if (secretCode.Contains(guess[i]))
            {
                misplaced++;
            }
        }
    }

}