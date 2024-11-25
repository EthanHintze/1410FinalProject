namespace PersonalManager.Logic;

public class Event : ICalendarItem
{
    private string _eventName{get;}
    private DateTime _scheduledTime{get;}
    private string _eventDescription{get;}
    public string eventName{get => _eventName;}
    public string eventDescription{get => _eventDescription;}
    public DateTime scheduledTime{get => _scheduledTime;}

    public Event(string eventName, DateTime scheduledTime, string eventDescription)
    {
        _eventName = eventName;
        _scheduledTime = scheduledTime;
        _eventDescription = eventDescription;
    }

}