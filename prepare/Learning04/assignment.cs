class Assignment{
    protected string _studentName;
    private string _topic;


    public Assignment(string name, string topic){
        _studentName = name;
        _topic = topic;
    }

    public string GetStudentName(){
        return _studentName;
    }
    public string GetSummary(){
        return $"Name: {_studentName} - Topic: {_topic}";
    }
}