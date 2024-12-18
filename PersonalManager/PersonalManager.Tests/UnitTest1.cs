using PersonalManager.Logic;

namespace PersonalManager.Tests;

public class StartManager
{
    MainRunner personalManager = new MainRunner();
    //Feature 1: Daily Calendar Tests
    //(REQ#1.1.1)
    [Fact]
    void CanAddNewDailySchedule()
    {
        var NewDay = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(NewDay);
        bool scheduleAdded = personalManager.AddNewDailySchedule(NewDailySchedule);
        Assert.True(scheduleAdded);
    }
    //(REQ#1.1.2)
    [Fact]
    void CannotAddDuplicateSchedules()
    {
        var NewDay = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(NewDay);
        bool scheduleAdded = personalManager.AddNewDailySchedule(NewDailySchedule);
        bool scheduleAddedAgain = personalManager.AddNewDailySchedule(NewDailySchedule);
        Assert.False(scheduleAddedAgain);
    }
    //Feature 2: Task Tests
    //(REQ#1.2.1)
    [Fact]
    public void CanAddTaskToDayExistingDay()
    {
        var day = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(day);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", day);
        bool taskAdded = personalManager.AddTaskToDay(task, day);
        Assert.True(taskAdded);
    }
    //(REQ#1.2.2)
    [Fact]
    public void CanAddTaskToDayNonexistingDay()
    {
        var newDay = new DateOnly(2024, 2, 9);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", newDay);
        bool taskAdded = personalManager.AddTaskToDay(task, newDay);
        Assert.True(taskAdded);
    }
    [Fact]
    public void CannotAddDuplicateTasks()
    {
        var day = new DateOnly(2024, 2, 8);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", day);
        bool taskAdded = personalManager.AddTaskToDay(task, day);
        bool duplicateTaskAdded = personalManager.AddTaskToDay(task, day);
        Assert.False(duplicateTaskAdded);
    }
    [Fact]
    public void CanToggleComplete()
    {
        var day = new DateOnly(2024, 2, 8);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", day);
        task.ToggleComplete();
        Assert.True(task.isComplete);
    }
    [Fact]
    public void CanToggleIncomplete()
    {
        var day = new DateOnly(2024, 2, 8);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", day);
        task.ToggleComplete();
        task.ToggleComplete();
        Assert.False(task.isComplete);
    }
    //Feature 3: Reminder Tests
    //(REQ#1.3.1)
    [Fact]
    public void CanAddReminderToDayExistingDay()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var reminder = personalManager.CreateNewReminder("Clean", time);
        bool reminderAdded = personalManager.AddReminderToDay(reminder, day);
        Assert.True(reminderAdded);
    }
    [Fact]
    public void CanAddReminderToDayNonexistingDay()
    {
        var newDay = new DateOnly(2024, 2, 9);
        var time = new TimeOnly(3, 2, 9);
        var reminder = personalManager.CreateNewReminder("Clean", time);
        bool reminderAdded = personalManager.AddReminderToDay(reminder, newDay);
        Assert.True(reminderAdded);
    }
    //(REQ#1.3.2)
    [Fact]
    public void CannotAddDuplicateReminder()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var reminder = personalManager.CreateNewReminder("Clean", time);
        bool reminderAdded = personalManager.AddReminderToDay(reminder, day);
        bool duplicateReminderAdded = personalManager.AddReminderToDay(reminder, day);
        Assert.False(duplicateReminderAdded);
    }
    //Feature 4: Event Tests
    //(REQ#1.4.1)
    [Fact]
    public void CanAddEventToDayExistingDay()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", time, day);
        bool eventAdded = personalManager.AddEventToDay(newEvent);
        Assert.True(eventAdded);
    }
    [Fact]
    public void CanAddEventToDayNonexistingDay()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", time, day);
        bool eventAdded = personalManager.AddEventToDay(newEvent);
        Assert.True(eventAdded);
    }
    //(REQ#1.4.2)
    [Fact]
    public void CannotAddDuplicateEventAtTheSameTime()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", time, day);
        bool eventAdded = personalManager.AddEventToDay(newEvent);
        bool duplicateEventAdded = personalManager.AddEventToDay(newEvent);
        Assert.False(duplicateEventAdded);
    }
    //Feature 5: Alarm Tests
    //(REQ#1.5.1)
    [Fact]
    public void CanAddAlarm()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var alarm = personalManager.CreateNewAlarm(time);
        bool alarmAdded = personalManager.AddAlarmToDay(alarm, day);
        Assert.True(alarmAdded);
    }
    [Fact]
    //(REQ#1.5.2)
    public void CannotAddDuplicateAlarm()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var alarm = personalManager.CreateNewAlarm(time);
        bool alarmAdded = personalManager.AddAlarmToDay(alarm, day);
        bool duplicateAlarmAdded = personalManager.AddAlarmToDay(alarm, day);
        Assert.False(duplicateAlarmAdded);
    }
    //Feature 6: Notes Test
    //(REQ#1.6.1)
    [Fact]
    public void CanAddNote()
    {
        var day = new DateOnly(2024, 2, 8);
        string note = "today i saw a balloon";
        var newNote = personalManager.CreateNewNote(note, day);
        bool noteAdded = personalManager.AddNoteToDay(newNote);
        Assert.True(noteAdded);
    }
    //(REQ#1.6.2)
    [Fact]
    public void CanAddNoteToNonExistentDay()
    {
        var day = new DateOnly(2024, 10, 8);
        string note = "today i saw a balloon";
        var newNote = personalManager.CreateNewNote(note, day);
        bool noteAdded = personalManager.AddNoteToDay(newNote);
        Assert.True(noteAdded);
    }
    //Feature 7: Weekly Calendar
    //(REQ#1.7.1)
    public void MakeWeeklyCalendar()
    {
        var weeklyCalendar = personalManager.GetWeeklyCalenders();
        Assert.True(weeklyCalendar.Count() == 7);
    }
}