namespace PersonalManager.Logic;

public class Alarm : ICalendarItem
{
    private TimeOnly _setTime{get;}

    public Alarm(TimeOnly setTime)
    {
        _setTime = setTime;
    }
    public void IsTime()
    {
        Console.Beep();
    }

}
        