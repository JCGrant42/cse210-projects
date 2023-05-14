class Entry{
    public int _entryNumber;
    public string _prompt;
    public string _entry;
    public DateTime _datetime;
 

    public void AssignPrompt(){
        Prompt prompt = new Prompt();
        _prompt = prompt.GetRandomPrompt();
    }
    
    public void DisplayEntry(){
        Console.WriteLine($"\nEntry {_entryNumber}\n{_datetime.ToString("f")}\n{_prompt}\n{_entry}");
    } 
}