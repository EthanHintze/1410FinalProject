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
    public Event CreateNewCalendarEvent(string eventName, string eventDescription, TimeOnly scheduledTime, DateOnly scheduledDate)
    {
        Event newEvent = new Event(eventName, scheduledTime, scheduledDate, eventDescription);
        return newEvent;
    }
    public Alarm CreateNewAlarm(TimeOnly givenTime)
    {
        Alarm newAlarm = new Alarm(givenTime);
        return newAlarm;
    }
    public Note CreateNewNote(string Note, DateOnly givenDate)
    {
        Note newNote = new Note(Note, givenDate);
        return newNote;
    }

    //Adding new things to a daily schedule
    //Task
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
    //Reminder
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
    //Event
    public bool AddEventToDay(Event newEvent)
    {
        bool eventAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == newEvent.scheduledDate)
            {
                bool containsTask = schedule.CheckEvent(newEvent);
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
            DailyCalendar NewSchedule = new DailyCalendar(newEvent.scheduledDate);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddEvent(newEvent);
            eventAdded = true;
        }
        return eventAdded;

    }
    //Alarm
    public bool AddAlarmToDay(Alarm alarm, DateOnly givenDay)
    {
        bool alarmAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == givenDay)
            {
                bool containsAlarm = schedule.CheckAlarm(alarm);
                if (containsAlarm == false)
                {
                    schedule.AddAlarm(alarm);
                    alarmAdded = true;
                }
                schedlueExists = true;

            }
        }
        //Creates new schedule if one doesnt exist
        if (schedlueExists == false)
        {
            DailyCalendar NewSchedule = new DailyCalendar(givenDay);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddAlarm(alarm);
            alarmAdded = true;
        }
        return alarmAdded;

    }
    public bool AddNoteToDay(Note givenNote)
    {
        bool alarmAdded = false;
        bool schedlueExists = false;
        foreach (DailyCalendar schedule in _dailySchedules)
        {
            if (schedule.Date == givenNote.dateCreated)
            {
                schedule.AddNote(givenNote);
                alarmAdded = true;
                schedlueExists = true;

            }
        }
        //Creates new schedule if one doesnt exist
        if (schedlueExists == false)
        {
            DailyCalendar NewSchedule = new DailyCalendar(givenNote.dateCreated);
            CreateNewDailySchedule(NewSchedule);
            NewSchedule.AddNote(givenNote);
            alarmAdded = true;
        }
        return alarmAdded;

    }

}
