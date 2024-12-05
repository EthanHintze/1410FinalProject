namespace PersonalManager.Logic;

public class Reminder : ICalendarItem
{
    private string _reminderName;
    private TimeOnly _reminderTime;
    public string reminderName{get => _reminderName;}
    public string CalendarText
    {
        get
        {
            return $"Time {_reminderTime} Name:{_reminderName} ";
        }
    }
    public Reminder(string reminderName, TimeOnly reminderTime)
    {
        _reminderName = reminderName;
        _reminderTime = reminderTime;
    }
    

}