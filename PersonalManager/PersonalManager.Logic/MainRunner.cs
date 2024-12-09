namespace PersonalManager.Logic;

public class MainRunner
{
    private List<DailyCalendar> _dailySchedules { get; set; }
    public List<DailyCalendar> dailyCalendars { get { return _dailySchedules; } }
    private static MainRunner _instance;
    public static MainRunner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MainRunner();
            }
            return _instance;
        }
    }

    public MainRunner()
    {
        _dailySchedules = new List<DailyCalendar>();
    }
    //Creating new components
    public void CreateNewCalendar(DateOnly givenDay)
    {
        bool containsCalendar = false;
        DailyCalendar dailyCalendar = new DailyCalendar(givenDay);
        foreach (DailyCalendar day in _dailySchedules)
        {
            if (day.Date == givenDay)
            {
                containsCalendar = true;
            }
        }
        if (!containsCalendar)
        {
            _dailySchedules.Add(dailyCalendar);
        }
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
    //Calendar
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
        if (scheduleAdded != false)
        {
            _dailySchedules.Add(day);
        }
        return scheduleAdded;
    }
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
            DailyCalendar newSchedule = new DailyCalendar(givenDay);
            AddNewDailySchedule(newSchedule);
            newSchedule.AddTask(task);
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
            DailyCalendar newSchedule = new DailyCalendar(givenDay);
            AddNewDailySchedule(newSchedule);
            newSchedule.AddReminder(reminder);
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
            DailyCalendar newSchedule = new DailyCalendar(newEvent.scheduledDate);
            AddNewDailySchedule(newSchedule);
            newSchedule.AddEvent(newEvent);
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
            DailyCalendar newSchedule = new DailyCalendar(givenDay);
            AddNewDailySchedule(newSchedule);
            newSchedule.AddAlarm(alarm);
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
            DailyCalendar newSchedule = new DailyCalendar(givenNote.dateCreated);
            AddNewDailySchedule(newSchedule);
            newSchedule.AddNote(givenNote);
            alarmAdded = true;
        }
        return alarmAdded;

    }
    //Populates Weekly Calendar
    public WeeklyCalender PopulateWeeklyCalendar(WeeklyCalender weeklyCalender)
    {
        DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
        for (int i = 0; i < 7; i++)
        {
            bool schedlueExists = false;
            foreach (DailyCalendar schedule in _dailySchedules)
            {
                if (schedule.Date.Day == todaysDate.Day + i && schedule.Date.Month == todaysDate.Month)
                {
                    weeklyCalender.AddCalendarToWeek(schedule);

                    schedlueExists = true;
                }
            }
            //Creates new schedule if one doesnt exist
            if (schedlueExists == false)
            {
                DateOnly newDate = new DateOnly(todaysDate.Year, todaysDate.Day + i, todaysDate.Month);
                DailyCalendar newSchedule = new DailyCalendar(newDate);
                AddNewDailySchedule(newSchedule);
                weeklyCalender.AddCalendarToWeek(newSchedule);
            }
        }
        return weeklyCalender;
    }

}
