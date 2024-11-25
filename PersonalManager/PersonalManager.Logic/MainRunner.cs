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
        if (scheduleAdded != false)
        {
            _dailySchedules.Add(day);
        }
        return scheduleAdded;
    }
    public Task CreateNewTask(string taskName, string taskDescription, DateOnly date)
    {
        Task newTask = new Task(taskName, taskDescription, date);
        return newTask;
    }
    public Reminder CreateNewReminder(string reminderName, TimeOnly time)
    {
        Reminder newReminder = new Reminder(reminderName, time); ;
        return newReminder;
    }
    public Event CreateNewCalendarEvent(string eventName, string eventDescription, DateTime scheduledTime)
    {
        Event newEvent = new Event(eventName, scheduledTime, eventDescription);
        return newEvent;
    }

    //Adding new things to a daily schedule
    public bool AddTaskToDay(Task task, DateOnly givenDay)
    {
        bool taskAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == givenDay)
            {
                bool containsTask = schedule.CheckTasks(task);
                if (containsTask == false)
                {
                    schedule.AddTask(task);
                    taskAdded = true;
                }
                schedlueExists = true;

            }
        }
        //Creates new schedule if one doesnt exist
        if (schedlueExists == false)
        {
            DailyCalendar NewSchedule = new DailyCalendar(givenDay);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddTask(task);
            taskAdded = true;
        }
        return taskAdded;

    }
    public bool AddReminderToDay(Reminder reminder, DateOnly givenDay)
    {
        bool reminderAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == givenDay)
            {
                bool containsTask = schedule.CheckReminders(reminder);
                if (containsTask == false)
                {
                    schedule.AddReminder(reminder);
                    reminderAdded = true;
                }
                schedlueExists = true;

            }
        }
        //Creates new schedule if one doesnt exist
        if (schedlueExists == false)
        {
            DailyCalendar NewSchedule = new DailyCalendar(givenDay);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddReminder(reminder);
            reminderAdded = true;
        }
        return reminderAdded;

    }
    public bool AddEventToDay(Event newEvent)
    {
        bool eventAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == newEvent.scheduledTime.Date)
            {
                bool containsTask = schedule.CheckEvents(newEvent);
                if (containsTask == false)
                {
                    schedule.AddEvent(newEvent);
                    eventAdded = true;
                }
                schedlueExists = true;

            }
        }
        //Creates new schedule if one doesnt exist
        if (schedlueExists == false)
        {
            DailyCalendar NewSchedule = new DailyCalendar(givenDay);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddEvent(newEvent);
            eventAdded = true;
        }
        return eventAdded;

    }

}
