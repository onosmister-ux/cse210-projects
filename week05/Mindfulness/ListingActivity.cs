using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "When have you felt peace this month?",
        "Who are your heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you list positive things in your life."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine($"\n--- {prompt} ---");

        Console.WriteLine("\nYou may begin in:");
        ShowCountDown(5);

        List<string> items = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        Console.WriteLine("\nStart listing items (press Enter after each):");

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");

        DisplayEndingMessage();
    }
}