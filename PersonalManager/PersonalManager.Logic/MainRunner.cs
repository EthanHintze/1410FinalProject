using System.Globalization;

namespace PersonalManager.Logic;

public class MainRunner
{
    private List<DailyCalendar> _dailySchedules { get; set; }
    public MainRunner()
    {
        _dailySchedules = new List<DailyCalendar>();
    }
    //Creating new components
    public bool CreateNewDailySchedule(DailyCalendar day)
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
    //Adding new things to a daily schedule
    public bool AddTaskToDay(Task task, DailyCalendar givenDay)
    {
        bool taskAdded = false;
        if (_dailySchedules.Contains(givenDay))
        {
            foreach(Task task in givenDay._tasks)
            givenDay.AddTask(task);
        }
        //Creates new schedule if it doesn't already contain it
        else
        {
            _dailySchedules.Add(givenDay);
            givenDay.AddTask(task);
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
