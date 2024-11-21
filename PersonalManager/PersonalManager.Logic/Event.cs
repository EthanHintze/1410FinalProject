namespace PersonalManager.Logic;

public class Event : ICalendarItem
{
    private string _eventName{get;}
    private DateTime _scheduledTime{get;}
    private string _eventDescription{get;}

    public Event(string eventName, DateTime scheduledTime, string eventDescription)
    {
        _eventName = eventName;
        _scheduledTime = scheduledTime;
        _eventDescription = eventDescription;
    }

}