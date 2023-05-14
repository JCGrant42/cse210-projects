public class Prompt{
    public List<string> _promptList = new List<string>();

    Random rand = new Random();

    public void CreatePromptList(){
        string filename = "PromptList.txt";
        string[] prompts = System.IO.File.ReadAllLines(filename);
        _promptList.Clear();
        foreach (string prompt in prompts)
        {
            _promptList.Add(prompt);
        }
        // _promptList.Add("How have you seen God's hand in my life today?");
        // _promptList.Add("Who was the most interesting person I interacted with today?");
        // _promptList.Add("What was the best part of my day?");
        // _promptList.Add("What was the strongest emotion I felt today?");
        // _promptList.Add("What am I grateful for today?");
        // _promptList.Add("If I had one thing I could do over today, what would it be?");
    }

    public string GetRandomPrompt(){
        CreatePromptList();
        return _promptList[rand.Next(_promptList.Count)];
    }



    public void DisplayPrompts() {
        int promptNum = 1;
        foreach (string prompt in _promptList){
            Console.WriteLine($"{promptNum}. {prompt}");
            promptNum++;
            }
        }
    
    public void AddPrompt() {
        Console.WriteLine("Enter the prompt you would like to add: ");
        string userinput =  Console.ReadLine();
        _promptList.Add(userinput);
        RewritePromptFile();
    }

    public void DeletePrompt() {
        DisplayPrompts();
        Console.Write("Enter number of the prompt you would like to delete: ");
        try {
            int userinput = int.Parse(Console.ReadLine());
            string prompt = _promptList[userinput - 1];
            Console.WriteLine();
            Console.WriteLine(prompt);
            Console.Write("Are you sure you would like to delete the above prompt from the list? (Y/N): ");
            string DeletionConfirm = Console.ReadLine();
            if (DeletionConfirm.ToUpper() == "Y") {
                Console.WriteLine("Prompt Removed");
                _promptList.RemoveAt(userinput - 1);
                RewritePromptFile();
            }
        } catch {
            Console.WriteLine("Not a valid input");
        } 
    }

    public void RewritePromptFile() {
        string filename = "PromptList.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        foreach (string P in _promptList){
            outputFile.WriteLine(P);
        }
    }

    public void ManagePrompts(){
        CreatePromptList();
        bool run = true;
        while (run) {
            Console.WriteLine("\n1. Display prompts \n2. Add new prompt \n3. Delete prompt \n4. Exit");
            Console.Write("Enter Option (1-4): ");
            string userinput = Console.ReadLine();                
            switch (userinput)
            {
            case "1":
                DisplayPrompts();
                break;
            case "2":
                AddPrompt();
                break;
            case "3":
                DeletePrompt();
                break;
            case "4":
                run = false;
                break;
            default: 
                Console.WriteLine("Invalid input.");
                break;
            }       
        }
    }
}