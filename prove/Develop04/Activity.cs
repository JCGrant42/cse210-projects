class Activity{
    protected int _time;
    private string _activityName;
    private string _description;


    public Activity(string name, string description){
        _activityName = name;
        _description = description;

    }


  public void DoActivity(){
        //Display the starting message, gets the time the user wishes to run the activity, and displays the loading animation
        DisplayStart();
        //Runs the starting portion of the code which is unique to each activity.
        ActivityBeginning();
        //calls the function to run a loop for the time the user chose, inside the loop it calls a funtion that will run the code which is unique to each activity.
        ActivityRunLoop();
        //Displays the ending portion of the activity
        DisplayEnd();
        Console.WriteLine();
    }
    

    public void DisplayStart(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}. \n\n{_description} \n");
        _time = GetUserTime("Please enter how many seconds you wish to do the activity: ");
        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner();
    }

    protected virtual void ActivityBeginning(){
        //This line of code should never run, instead when this function is call 
        //it should call the ActivityBeginning function inside of the class that is being used.
        Console.WriteLine("Error");
    }

    private void ActivityRunLoop(){
        //Runs the loop for the amount of time the user selected
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_time);
        DateTime currentTime = DateTime.Now;
        while (currentTime < endTime){
            //Each time this loops, calls the code which is unique to each activity. 
            ActivityMainFunction(endTime);
            currentTime = DateTime.Now;
        }
    }

    protected virtual void ActivityMainFunction(DateTime endTime){
        //This line of code should never run, instead when this function is call 
        //it should call the ActivityMainFunction function inside of the class that is being used.
        Console.WriteLine("Error");
    }

    public void DisplayEnd(){
        Console.WriteLine("\nWell Done.");
        DisplaySpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_time} seconds of the {_activityName} ");
        DisplaySpinner();
    }




    public int GetUserTime(string message){
        //simple function that will continue to run until the user gives a valid int for the time. 
        Console.Write($"{message}");
        bool validInput = false;
        int time = 0;
        while (!validInput){
            string userinput = Console.ReadLine();
            validInput = int.TryParse(userinput, out time);
            if (!validInput) {
                Console.WriteLine("Invalid Input, please enter a number");
            }
        }
        return time;
    }

    public void DisplayCountdown(int time){
        for (int i = time; 0 < i; i--){
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");    
        }
    }

    public void DisplaySpinner(int time = 4){
        List<string> animationstring = new List<string>();
        animationstring.Add("|");
        animationstring.Add("/");
        animationstring.Add("-");
        animationstring.Add("\\");
        for (int i = time; 0 < i; i--){
            foreach (string s in animationstring){
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }



    public List<string> BuildList(string filename){
        List<string> list = new List<string>();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines) {
            list.Add(line);
        }
        return list;
    }

    public string GetRandomItem(List<string> list, List<string> usedList){
        if (list.Count == 0){
            foreach (string s in usedList){
                list.Add(s);
            }
            //list = new List<string>(usedList);
            usedList.Clear();
        }
        Random randomGen = new Random();
        int ranNumber = randomGen.Next(list.Count);

        string item = list[ranNumber];
        list.RemoveAt(ranNumber);
        usedList.Add(item);
        return item;
    }
}