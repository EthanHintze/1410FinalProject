namespace PersonalManager.Logic;

public class Event
{
    private string _eventName{get;}
    private TimeOnly _scheduledTime{get;}
    private string _eventDescription{get;}

    public Event(string eventName, TimeOnly scheduledTime, string eventDescription)
    {
        _eventName = eventName;
        _scheduledTime = scheduledTime;
        _eventDescription = eventDescription;
    }

}