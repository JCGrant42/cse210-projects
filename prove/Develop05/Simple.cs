class Simple : Goal{
    private bool _status;
    private int _deadlineDays;
    private DateTime _deadlineDate;


    public Simple (string goalType, string name, string description, int points, int reminderFrequency, DateTime createdDate, int deadline, bool status) : base(goalType, name, description, points, reminderFrequency, createdDate){
        _status = status;
        _deadlineDays = deadline;
        TimeSpan timeSpan = new TimeSpan(deadline, 0, 0, 0);
        _deadlineDate = _createdDate.Add(timeSpan);
    }


    public override int RecordEvent(){ 
        int reward = 0;
        if (!_status){
            Console.WriteLine($"Congratulations! You have earned {_points} points");
            reward = _points;
        } 
        else
        {
            Console.WriteLine($"This Goal is already completed");
        }
        _status = true;
        return reward;
    } 

    public override void DisplayGoal(){
        string mark = " ";
        if (_status){
            mark ="X";
        }
        string dlMessage = "";
        if (_deadlineDays != 0){
            if (CheckDeadlinePast()){
                dlMessage = "--Deadline Passed--";
            } 
            else{
                DateTime now = DateTime.Now.Date;
                int daysRemaining = 1 + (_deadlineDate - now).Days;
                dlMessage = $"-- Days remaining: {daysRemaining} --";
            }
        }
        Console.WriteLine($"[{mark}] {_name} ({_description}) {dlMessage}");

    } 
    
    public override void DisplayReminder(){
        if (!_status && !CheckDeadlinePast()){
            DateTime now = DateTime.Now.Date;
            TimeSpan timeSpan = now - _createdDate;
            if ((_reminderFrequency != 0) && (timeSpan.Days != 0)){
                int daysRemaining = 1 + (_deadlineDate - now).Days;
                if (daysRemaining == 1){
                    Console.WriteLine($"Last day to complete -- {_name} ({_description}) --");
                }
                else if (timeSpan.Days % _reminderFrequency == 0) {
                    Console.WriteLine($"Reminder: {_name} ({_description}) -- Deadline in {daysRemaining} days.");
                }
            }
        }
    }
    
    public override bool CheckDeadlinePast(){
        bool isPast = false;
        if (_deadlineDays != 0){
            DateTime now = DateTime.Now.Date;
            isPast = _deadlineDate < now;
        }
        return isPast;
    }

    public override string SaveString(){ 
        return $"{base.SaveString()}~{_deadlineDays}~{_status}";
    } 
}