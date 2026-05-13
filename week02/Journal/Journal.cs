using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
        }
        else
        {
            Console.WriteLine($"You have {_entries.Count} journal entries.");
            Console.WriteLine();

            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._mood}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();

                entry._date = parts[0];
                entry._mood = parts[1];
                entry._promptText = parts[2];
                entry._entryText = parts[3];

                _entries.Add(entry);
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}