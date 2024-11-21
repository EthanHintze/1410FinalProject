namespace PersonalManager.Logic;

public class Task
{
    private string _taskName{ get;}
    private string _taskDescription{ get;}
    private DateOnly _date{get;}
    private bool _isComplete{ get;}
    public string taskName {get => _taskName;}
    public string taskDescription {get => _taskDescription;}

    public Task(string taskName, string taskDescription, DateOnly date)
    {
        _taskName = taskName;
        _taskDescription = taskDescription;
        _date = date;
        _isComplete = false;
    }
}