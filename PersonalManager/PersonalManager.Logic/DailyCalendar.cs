namespace PersonalManager.Logic;

public class DailyCalendar 
{
    private List<Event> _schedule;
    private DateOnly _date{get;}
    private List<Task> _tasks;
    private List<Reminder> _reminders;
    private List<Alarm> _alarms;
    public DateOnly Date{get{return _date;}}

    public DailyCalendar(DateOnly date)
    {
        _tasks = new List<Task>();
        _reminders = new List<Reminder>();
        _schedule = new List<Event>();
        _alarms = new List<Alarm>();
        _date = date;
    }
    //Checks for items in the day
    public bool CheckTasks(Task givenTask)
    {
        bool containsTask = false;
        foreach(Task task in _tasks)
        {
            if(task.taskName == givenTask.taskName && task.taskDescription == givenTask.taskDescription)
            {
                containsTask = true;
            }
        }
        return containsTask;
    }
    public bool CheckReminders(Reminder givenReminder)
    {
        bool containsReminder = false;
        foreach(Reminder reminder in _reminders)
        {
            if(reminder.reminderName == givenReminder.reminderName)
            {
                containsReminder = true;
            }
        }
        return containsReminder;
    }
     public bool CheckEvent(Event givenEvent)
    {
        bool containsEvent = false;
        foreach(Event nEvent in _schedule)
        {
            if(nEvent.eventName == givenEvent.eventName && nEvent.scheduledTime == givenEvent.scheduledTime)
            {
                containsEvent = true;
            }
        }
        return containsEvent;
    }
    public bool CheckAlarm(Alarm givenAlarm)
    {
        bool containsAlarm = false;
        foreach(Alarm alarm in _alarms)
        {
            if(alarm.setTime == givenAlarm.setTime)
            {
                containsAlarm = true;
            }
        }
        return containsAlarm;
    }
    //Adding items to the day
    public void AddTask(Task task)
    {
        _tasks.Add(task);
    }
    public void AddReminder(Reminder reminder)
    {
        _reminders.Add(reminder);
    }
    public void AddEvent(Event newEvent)
    {
        _schedule.Add(newEvent);
    }
    public void AddAlarm(Alarm newAlarm)
    {
        _alarms.Add(newAlarm);
    }
    
    


}