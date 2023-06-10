class Reflection : Activity{
    private List<string> _promptList;
    private List<string> _questionList;
    private List<string> _UsedpromptList = new List<string>();
    private List<string> _UsedquestionList = new List<string>();
    private int _waitTime;


    public Reflection(string name = "Reflection Activity",  
                    string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
                    : base(name, description){
        
        _promptList = base.BuildList("ReflectPromptList.txt");
        _questionList = base.BuildList("ReflectQuestionList.txt");
    }


    protected override void ActivityBeginning(){
        _waitTime = base.GetUserTime("How long many seconds do you wish reflect on each question: ");
        Console.Clear();
        string prompt = GetRandomItem(_promptList, _UsedpromptList);
        Console.WriteLine($"Ponder the following prompt: \n\n - {prompt} - \n\nWhen you have finished considering the prompt, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Ponder on the following questions in relation to this experience.");
        base.DisplayCountdown(5);
        Console.Clear();  
        Console.WriteLine($"-- {prompt} --");
    }


    protected override void ActivityMainFunction(DateTime endTime){
        string question = GetRandomItem(_questionList, _UsedquestionList);
        Console.WriteLine($"{question} ");
        DisplaySpinner(_waitTime);
    }
    
}