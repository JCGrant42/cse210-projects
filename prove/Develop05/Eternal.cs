class Eternal : Goal{

    public Eternal (string goalType, string name, string description, int points, int reminderFrequency, DateTime createdDate) : base(goalType, name, description, points, reminderFrequency, createdDate){

    }

    public override int RecordEvent(){ 
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        return _points;
    } 

    public override void DisplayGoal(){ 
        Console.WriteLine($"{_name} ({_description}) -- Ongoing");
    } 

    public override void DisplayReminder(){
        if (!CheckDeadlinePast()){
            DateTime now = DateTime.Now.Date;
            TimeSpan timeSpan = now - _createdDate;
            if ((_reminderFrequency != 0) && (timeSpan.Days != 0) && (timeSpan.Days % _reminderFrequency == 0)){
                Console.Write("Reminder: ");
                DisplayGoal();
            }
        }
    }


}