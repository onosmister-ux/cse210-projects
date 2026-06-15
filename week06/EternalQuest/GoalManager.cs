using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        string choice = "";
        while (choice!= "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {_level} - {GetRank()}");
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[index];
        if (!goal.IsComplete())
        {
            int pointsEarned = 0;
            if (goal is SimpleGoal simple)
            {
                simple.RecordEvent();
                pointsEarned = int.Parse(goal.GetStringRepresentation().Split(":")[1].Split(",")[2]);
            }
            else if (goal is EternalGoal)
            {
                pointsEarned = int.Parse(goal.GetStringRepresentation().Split(":")[1].Split(",")[2]);
            }
            else if (goal is ChecklistGoal checklist)
            {
                checklist.RecordEvent();
                pointsEarned = checklist.GetPoints() + checklist.GetBonus();
            }
            
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            CheckLevelUp();
        }
        else
        {
            Console.WriteLine("You have already completed this goal.");
        }
        Console.WriteLine();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                if (bool.Parse(details[3])) goal.RecordEvent();
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[3]));
                int timesCompleted = int.Parse(details[5]);
                for (int j = 0; j < timesCompleted; j++) goal.RecordEvent();
                _goals.Add(goal);
            }
        }
        CheckLevelUp();
    }

    // EXCEEDING REQUIREMENTS: Leveling system + Rank titles
    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n*** LEVEL UP! You are now Level {_level} - {GetRank()} ***\n");
        }
    }

    private string GetRank()
    {
        if (_level >= 13) return "Ninja Unicorn";
        else if (_level >= 10) return "Master Disciple";
        else if (_level >= 7) return "Faithful Warrior";
        else if (_level >= 4) return "Diligent Seeker";
        else return "New Convert";
    }
}