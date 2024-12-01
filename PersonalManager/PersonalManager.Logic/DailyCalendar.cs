namespace PersonalManager.Logic;

public class DailyCalendar
{
    private List<Event> _schedule;
    private DateOnly _date{get;}
    private List<Task> _tasks;
    private List<Reminder> _reminders;
    public DateOnly Date{get{return _date;}}

    public DailyCalendar(DateOnly date)
    {
        _tasks = new List<Task>();
        _reminders = new List<Reminder>();
        _schedule = new List<Event>();
        _date = date;
    }
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
    public void AddTask(Task task)
    {
        _tasks.Add(task);
    }
    public void AddReminder(Reminder reminder)
    {
        _reminders.Add(reminder);
    }
    public void AddReminder(Event newEvent)
    {
        _schedule.Add(newEvent);
    }
    
    


}