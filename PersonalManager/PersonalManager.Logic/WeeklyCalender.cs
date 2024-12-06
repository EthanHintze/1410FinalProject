namespace PersonalManager.Logic;

public class WeeklyCalender
{
    private List<DailyCalendar> _weeklyCalendar{get;}
    public List<DailyCalendar> WeeklyCalendar{get=> _weeklyCalendar;}

    public WeeklyCalender()
    {
        _weeklyCalendar = new List<DailyCalendar>();   
    }

}