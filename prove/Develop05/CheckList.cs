class CheckList : Goal{
    private int _totalCount;
    private int _currentCount;
    private int _bonusPoints;
    private int _deadlineDays;
    private DateTime _deadlineDate;



    public CheckList (string goalType, string name, string description, int points, int reminderFrequency, DateTime createdDate, int deadline, int bonusPoints, int totalCount, int currentCount) : base(goalType, name, description, points,  reminderFrequency, createdDate){
    _totalCount = totalCount;
    _bonusPoints = bonusPoints;
    _currentCount = currentCount;
    _deadlineDays = deadline;
    TimeSpan timeSpan = new TimeSpan(deadline, 0, 0, 0);
    _deadlineDate = _createdDate.Add(timeSpan);
    }

    public override int RecordEvent(){
        int totalPoints = 0;
        _currentCount++;
        if (_currentCount < _totalCount){
            totalPoints = _points;
            Console.WriteLine($"Congratulations! You have earned {totalPoints} points");
        }
        else if (_currentCount == _totalCount){
            totalPoints = _bonusPoints + _points;
            Console.WriteLine($"Congratulations! You have earned {totalPoints} points");
        } 
        else
        {
            Console.WriteLine($"This Goal is already completed");
        }
        return totalPoints;
    } 

    public override void DisplayGoal(){ 
        string mark = " ";
        if (_currentCount >= _totalCount){
            mark ="X";
        }
        string dlMessage = "";
        if (_deadlineDays != 0){
            if (CheckDeadlinePast()){
                dlMessage = $"Count {_currentCount}/{_totalCount} --Deadline Passed--";
            } 
            else{
                DateTime now = DateTime.Now.Date;
                int daysRemaining = 1 + (_deadlineDate - now).Days;
                dlMessage = $"Currently completed {_currentCount}/{_totalCount} -- Days remaining: {daysRemaining} --";
            }
        }
        Console.WriteLine($"[{mark}] {_name} ({_description}) -- {dlMessage}");
    }

    public override void DisplayReminder(){
        if ((_currentCount < _totalCount) && !CheckDeadlinePast()){
            DateTime now = DateTime.Now.Date;
            TimeSpan timeSpan = now - _createdDate;
            if ((_reminderFrequency != 0) && (timeSpan.Days != 0)){
                int daysRemaining = 1 + (_deadlineDate - now).Days;
                if (daysRemaining == 1){
                    Console.Write($"Last day to complete -- {_name} ({_description}) Count {_currentCount}/{_totalCount} --");
                }
                else if (timeSpan.Days % _reminderFrequency == 0) {
                    Console.Write($"Reminder: {_name} ({_description}) -- Count {_currentCount}/{_totalCount} -- Deadline in {daysRemaining} days.");
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
        return $"{base.SaveString()}~{_deadlineDays}~{_bonusPoints}~{_totalCount}~{_currentCount}";
    } 
}