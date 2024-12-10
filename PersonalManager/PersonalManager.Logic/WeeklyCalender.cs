namespace PersonalManager.Logic;
//(REQ#2.1.2)
public class WeeklyCalender
{
    private List<DailyCalendar> _weeklyCalendar{get;}
    public List<DailyCalendar> WeeklyCalendar{get=> _weeklyCalendar;}

    public WeeklyCalender()
    {
        _weeklyCalendar = new List<DailyCalendar>();   
    }
    public void AddCalendarToWeek(DailyCalendar newCalendar)
    {
        _weeklyCalendar.Add(newCalendar);
    }

}