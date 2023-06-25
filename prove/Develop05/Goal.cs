class Goal{
    protected string _goalType;
    protected string _name;
    protected string _description;
    protected int _points; 
    protected DateTime _createdDate;
    protected int _reminderFrequency;


    public Goal(string goalType, string name, string description, int points, int reminderFrequency, DateTime createdDate){
        _goalType = goalType;
        _name = name; 
        _description = description; 
        _points = points;
        _createdDate = createdDate;
        _reminderFrequency = reminderFrequency;
    }

    public virtual int RecordEvent(){ 
        int x = 0;
        return x;
    } 

    public virtual void DisplayGoal(){ 

    } 

    public virtual void DisplayReminder(){

    }

    public virtual bool CheckDeadlinePast(){
        return true;
    }

    public virtual string SaveString(){ 
        return $"{_goalType}~{_name}~{_description}~{_points}~{_reminderFrequency}~{_createdDate}";
    } 

}
    
    
    
    