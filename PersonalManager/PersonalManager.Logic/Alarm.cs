namespace PersonalManager.Logic;

public class Alarm : ICalendarItem
{
    private TimeOnly _setTime{get;}
    public TimeOnly setTime{get => _setTime;}   
public string CalendarText
    {
        get
        {
            return $"Scheduled TIme:{_setTime}";
        }
    }
    public Alarm(TimeOnly setTime)
    {
        _setTime = setTime;
    }
    public void IsTime()
    {
        Console.Beep();
    }

}
        