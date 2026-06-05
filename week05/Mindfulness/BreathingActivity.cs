using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        bool breatheIn = true;

        while (DateTime.Now < end)
        {
            if (breatheIn)
            {
                Console.Write("\nBreathe in... ");
                ShowCountDown(4);
                Console.WriteLine();
            }
            else
            {
                Console.Write("\nBreathe out... ");
                ShowCountDown(4);
                Console.WriteLine();
            }

            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}