class GoalControls{
    private List<Goal> _goalsList = new List<Goal>();
    protected int _totalPoints;


    public int GetTotalPoints(){
        return _totalPoints;
    }
    public void DisplayReminders(){
        foreach (Goal goal in _goalsList){
            goal.DisplayReminder();
        }
    }
    
    public void CreateGoal(){ 
        Console.Write("The types of goals are: \n1. Simple \n2. Eternal \n3. Checklist \n4. Go Back \nWhich type would you like to create: ");
        string typeSelection = Console.ReadLine();
        string goalName = ""; 
        string goalDescript = ""; 
        int pointsNumber = 0;
        int reminderFrequency = 0;
        int deadlineDays = 0;
        if (typeSelection == "1" || typeSelection == "2" || typeSelection == "3"){
            (goalName, goalDescript, pointsNumber, reminderFrequency) = GetGoalInfo();
        }
        switch (typeSelection)
        {
        case "1":
            deadlineDays = GetValiudNumber("Enter a deadline, in days, for this goal, type '0' to forgo a deadline: ");
            Goal simple = new Simple("Simple", goalName, goalDescript, pointsNumber, reminderFrequency, DateTime.Now.Date, deadlineDays, false);
            _goalsList.Add(simple);
            break;
        case "2":
            Goal eternal = new Eternal("Eternal", goalName, goalDescript, pointsNumber, reminderFrequency, DateTime.Now.Date);
            _goalsList.Add(eternal);
            break;
        case "3":
            deadlineDays = GetValiudNumber("Enter a deadline, in days, for this goal, type '0' to forgo a deadline: ");
            int totalCount = GetValiudNumber("Please Enter how many time you want to complete this goal: ");
            int bonusPoints = GetValiudNumber("Please Enter the bonus points for completing it this amount of times: ");
            Goal checklist = new CheckList("CheckList", goalName, goalDescript, pointsNumber, reminderFrequency, DateTime.Now.Date, deadlineDays, bonusPoints, totalCount, 0);
            _goalsList.Add(checklist);
            break;
        case "4":
            break;
        default: 
            Console.WriteLine("Invalid input. Please select 1-3");
            break;
        }      
    }


    private (string, string, int, int) GetGoalInfo(){
        Console.Write("Please Enter the name of the goal: ");
        string goalName = Console.ReadLine();
        Console.Write("Please Enter the description of the goal: ");
        string goalDescript = Console.ReadLine();
        int pointsNumber = GetValiudNumber("Please Enter the amount of point associated with this goal: ");
        int reminderFrequency = GetValiudNumber("How often, in days, do you want to be reminded about this goal (Type '0' to forgo a reminder): ");
        return (goalName, goalDescript, pointsNumber, reminderFrequency);
    }


    public void ListGoals(){ 
        for (int i = 0; i < _goalsList.Count; i++){
            Console.Write($"{i + 1}. ");
            _goalsList[i].DisplayGoal();
        }
    }


    public void SaveFile(){ 
        Console.Write("What would you like to save the file as: ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_totalPoints}");
            foreach (Goal goal in _goalsList){
                outputFile.WriteLine($"{goal.SaveString()}");
            }
        }
    }


    public void LoadFile(){ 
        Console.Write("What file would you like to load: ");
        string filename = Console.ReadLine();
        try{
            string[] lines = System.IO.File.ReadAllLines(filename);
            _goalsList.Clear();
            _totalPoints = int.Parse(lines[0]);
            lines = lines.Skip(1).ToArray();
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                switch(parts[0]){
                    case "Simple":
                        Goal simple = new Simple(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), DateTime.Parse(parts[5]), int.Parse(parts[6]), Boolean.Parse(parts[7]));
                        _goalsList.Add(simple);
                        break;
                    case "Eternal":
                        Goal eternal = new Eternal(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), DateTime.Parse(parts[5]));
                        _goalsList.Add(eternal);
                        break;
                    case "CheckList":
                        Goal checklist = new CheckList(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), DateTime.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]));
                        _goalsList.Add(checklist);
                        break;
                }
            }
        } catch {
            Console.WriteLine("File does not exist.");
        }
    }


    public void Record(){ 
        Console.WriteLine("The goals are:");
        ListGoals();
        int userChoice = GetValiudNumber("Which Goal did you acomplish: ");
        if (userChoice > 0 && userChoice <= _goalsList.Count ){
            Goal chosenGoal = _goalsList[userChoice - 1];
            if (!chosenGoal.CheckDeadlinePast()){
                _totalPoints += chosenGoal.RecordEvent();
            }
            else {
                Console.WriteLine("The deadline for this goal has passed.");
            }
        }
        else {
            Console.WriteLine($"Invalid Choice, please select a option from 1-{_goalsList.Count}");
        }
    }

          
    private int GetValiudNumber(string prompt){
        bool validNubmer = false;
        int number = 0;
        while (!validNubmer){
            Console.Write(prompt);
            string goalPoints = Console.ReadLine();
            validNubmer = int.TryParse(goalPoints, out number);
            if (!validNubmer){
                Console.WriteLine("Invalid Input, please enter a valid number");
            }
        }
        return number;
    }

    
}