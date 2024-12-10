namespace PersonalManager.Logic;
//(REQ#2.2.1)
public class Task : ICalendarItem
{
    private string _taskName { get; }
    private string _taskDescription { get; }
    private DateOnly _date { get; }
    private bool _isComplete { get; set; }
    public string taskName { get => _taskName; }
    public string taskDescription { get => _taskDescription; }
    public bool isComplete { get => _isComplete; }

    public string CalendarText
    {
        get
        {
            return $"-Task- Name:{_taskName} Description:{_taskDescription} Complete:{_isComplete}";
        }
    }

    public Task(string taskName, string taskDescription, DateOnly date)
    {
        _taskName = taskName;
        _taskDescription = taskDescription;
        _date = date;
        _isComplete = false;
    }
    public void ToggleComplete()
    {
        if (_isComplete)
        { 
            _isComplete = false; 
        }
        else
        {
            _isComplete = true;
        }
    }
}