using System.Globalization;

namespace PersonalManager.Logic;

public class MainRunner
{
    private List<DailyCalendar> _dailySchedules { get; set; }
    public MainRunner()
    {
        _dailySchedules = new List<DailyCalendar>();
    }
    public bool AddNewDailySchedule(DailyCalendar day)
    {
        bool scheduleAdded = true;
        foreach (DailyCalendar cal in _dailySchedules)
        {
            if (cal.Date == day.Date)
            {
                scheduleAdded = false;
            }
        }
        _dailySchedules.Add(day);
        return scheduleAdded;


    }
    public void AddTaskToDay(Task task, DailyCalendar calendar)
    {
        if (_dailySchedules.Contains(calendar))
        {
            calendar.AddTask(task);
        }
        else
        {
            _dailySchedules.Add(calendar);
            calendar.AddTask(task);

        }
    }
     public void AddReminderToDay(Reminder reminder, DailyCalendar calendar)
    {
        if (_dailySchedules.Contains(calendar))
        {
            calendar.AddReminder(reminder);
        }
        else
        {
            _dailySchedules.Add(calendar);
            calendar.AddReminder(reminder);

        }
    }

}
