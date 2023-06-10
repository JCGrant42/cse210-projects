class Listing : Activity{
    private List<string> _promptList;
    private List<string> _UsedpromptList = new List<string>();
    private List<string> _answerList = new List<string>();


    public Listing(string name = "Breathing Activity",  
                    string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") 
                    : base(name, description){

        _promptList = base.BuildList("ListingPromptList.txt");
    }


    protected override void ActivityBeginning(){
        string prompt = GetRandomItem(_promptList, _UsedpromptList);
        Console.WriteLine($"List as many responses that you can to the following prompt: \n - {prompt} -");
        Console.Write($"You may begin in: ");
        DisplayCountdown(5);
        Console.WriteLine($"\nBegin");
    }


    protected override void ActivityMainFunction(DateTime endTime){
        string answer = Console.ReadLine();
        _answerList.Add(answer);
        DateTime currentTime = DateTime.Now;
        if (currentTime > endTime){
            Console.WriteLine($"\nYou listed {_answerList.Count} things.\n");
        }
    }

}