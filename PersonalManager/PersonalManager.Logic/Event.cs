namespace PersonalManager.Logic;

public class Event : ICalendarItem
{
    private string _eventName{get;}
    private TimeOnly _scheduledTime{get;}
    private DateOnly _scheduledDate{get;}
    private string _eventDescription{get;}
    public string eventName{get => _eventName;}
    public string eventDescription{get => _eventDescription;}
    public TimeOnly scheduledTime{get => _scheduledTime;}
    public DateOnly scheduledDate{get => _scheduledDate;}
    public string CalendarText
    {
        get
        {
            return $"{_scheduledTime} Name:{_eventName} Description:{_eventDescription}";
        }
    }

    public Event(string eventName, TimeOnly scheduledTime, DateOnly scheduledDate, string eventDescription)
    {
        _eventName = eventName;
        _scheduledTime = scheduledTime;
        _scheduledDate = scheduledDate;
        _eventDescription = eventDescription;
    }

}