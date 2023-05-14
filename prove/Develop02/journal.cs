public class Journal{
    List<Entry> _entryList = new List<Entry>();

    public void Write() {
        //Creates the entry object
        Entry entry = new Entry();
        //Adds the entry's number and displays it
        entry._entryNumber = _entryList.Count + 1;
        Console.WriteLine($"Entry number {entry._entryNumber}");
        //Assigns the entry's prompt and displays it
        entry.AssignPrompt();
        Console.WriteLine(entry._prompt);
        //Gets the users entry and adds it
        entry._entry = Console.ReadLine();
        //Gets the datetime, adds and displays it
        entry._datetime = DateTime.Now;
        Console.WriteLine($"Entry added at {entry._datetime.ToString("f")}");
         Console.WriteLine();
        //Adds the entry to the list
        _entryList.Add(entry);
    }

    public void DisplayJounral() {
        foreach (Entry entry in _entryList){
        entry.DisplayEntry();
        }
        Console.WriteLine();
    }

    public void DeleteEntry() {
        Console.Write("Enter Entry you would like to remove: ");
        try {
            int userinput = int.Parse(Console.ReadLine());
            if (userinput == _entryList[userinput - 1]._entryNumber) {  
                _entryList[userinput - 1].DisplayEntry();
                Console.Write("Are you sure you would like to remove an entry (Y/N): ");
                string DeletionConfirm = Console.ReadLine();
                if (DeletionConfirm.ToUpper() == "Y") {
                    Console.WriteLine($"Entry {userinput} deleted");
                    _entryList.RemoveAt(userinput - 1);
                    RewriteList();
                }
            }
            else{
                Console.WriteLine($"Entry {userinput} does not exist");
            }
        } catch {
            Console.WriteLine("Not a valid input");
        } 
    }

    public void RewriteList() {
        int entryNum = 1;
        foreach (Entry entry in _entryList){
            entry._entryNumber = entryNum;
            entryNum++;
        }
    }
        
    public void Save() {
        Console.Write("What would you like to save the file as: ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entryList){
                //outputFile.WriteLine($"{entry._entryNumber}~{entry._datetime}~{entry._prompt}~{entry._entry}");
                outputFile.WriteLine($"{entry._entryNumber}~");
                outputFile.WriteLine($"{entry._datetime}~");
                outputFile.WriteLine($"{entry._prompt}~");
                outputFile.WriteLine($"{entry._entry}");
                outputFile.WriteLine("===");
            }
        }
    }
    public void Load() {
        Console.Write("What file would you like to load: ");
        string filename = Console.ReadLine();
        try{
            string[] lines = System.IO.File.ReadAllLines(filename);
            _entryList.Clear();

            string journal = string.Concat(lines).TrimEnd('='); 
            string[] entrys = journal.Split("===");
            foreach (string entry in entrys)
            {
                Entry NewEntry = new Entry();
                string[] parts = entry.Split("~");

                NewEntry._entryNumber = int.Parse(parts[0]);
                NewEntry._datetime = DateTime.Parse(parts[1]);
                NewEntry._prompt = parts[2];
                NewEntry._entry = parts[3].Trim();
                _entryList.Add(NewEntry);
            }
        } catch {
            Console.WriteLine("File does not exist.");
        }
    }

}