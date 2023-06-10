class Breathing : Activity{
    private int _breathTime;

    public Breathing(string name = "Breathing Activity",  
                    string description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
                    : base(name, description){
        
    }
    

    protected override void ActivityBeginning(){
        _breathTime = base.GetUserTime("How long many seconds do you wish each breath to be: ");
        Console.Clear();
        Console.Write($"Begin in: ");
        DisplayCountdown(3);
        Console.WriteLine("\n");    
    }


    protected override void ActivityMainFunction(DateTime endTime){
        Breath("Breath In...", endTime);
        Breath("Now Breath Out...", endTime);
        Console.WriteLine();
    }


    private void Breath(string message, DateTime endTime){
        DateTime currentTime = DateTime.Now;
        if (currentTime < endTime)
        {
            Console.WriteLine($"{message} ");
            DisplayCountdown(_breathTime);
        }
    }

}