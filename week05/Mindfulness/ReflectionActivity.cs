using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you stood up for someone.",
        "Think of a time you did something difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you did something selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel at the time?",
        "What did you learn from it?",
        "How can you apply this in the future?",
        "What made this experience stand out?",
        "What strength did you show?",
        "What would you do differently next time?"
    };

    private Random _random = new Random();

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity helps you reflect on moments of strength and resilience."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n--- {prompt} ---");

        Console.WriteLine("\nPress Enter when you are ready...");
        Console.ReadLine();

        Console.WriteLine("\nNow reflect on the following questions:");
        ShowSpinner(2);

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            string question = _questions[_random.Next(_questions.Count)];

            Console.WriteLine("\n> " + question);
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}