using PersonalManager.Logic;

namespace PersonalManager.Tests;

public class StartManager
{
    MainRunner personalManager = new MainRunner();
    //Feature 1: Daily Calendar Tests
    [Fact]
    void CanAddNewDailySchedule()
    {
        var NewDay = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(NewDay);
        bool scheduleAdded = personalManager.CreateNewDailySchedule(NewDailySchedule);
        Assert.True(scheduleAdded);
    }
    [Fact]
    void CannotAddDuplicateSchedules()
    {
        var NewDay = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(NewDay);
        bool scheduleAdded = personalManager.CreateNewDailySchedule(NewDailySchedule);
        bool scheduleAddedAgain = personalManager.CreateNewDailySchedule(NewDailySchedule);
        Assert.False(scheduleAddedAgain);
    }
    //Feature 2: Task Tests
    [Fact]
    public void CanAddTaskToDayExistingDay()
    {
        var day = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(day);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", day);
        bool taskAdded = personalManager.AddTaskToDay(task, day);
        Assert.True(taskAdded);
    }
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
    //Feature 3: Reminder Tests
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
    // [Fact]
    // public void CanAddEventToDayExistingDay()
    // {
    //     var scheduledEventTime = new DateTime(2024, 2, 8, 3, 2, 9);
    //     var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", scheduledEventTime);
    //     bool eventAdded = personalManager.AddEventToDay(newEvent, scheduledEventTime);
    //     Assert.True(eventAdded);
    // }
    // [Fact]
    // public void CanAddEventToDayNonexistingDay()
    // {
    //     var scheduledEventTime = new DateTime(2024, 9, 8, 3, 2, 9);
    //     var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", scheduledEventTime);
    //     bool eventAdded = personalManager.AddEventToDay(newEvent, scheduledEventTime);
    //     Assert.True(eventAdded);
    // }
    // [Fact]
    // public void CannotAddDuplicateEventAtTheSameTime()
    // {
    //     var scheduledEventTime = new DateTime(2024, 9, 8, 3, 2, 9);
    //     var newEvent = personalManager.CreateNewCalendarEvent("Clean", "", scheduledEventTime);
    //     bool eventAdded = personalManager.AddEventToDay(newEvent, scheduledEventTime);
    //     bool duplicateEventAdded = personalManager.AddEventToDay(newEvent, scheduledEventTime);
    //     Assert.False(duplicateEventAdded);
    // }
    //Feature 5: Alarm Tests
     [Fact]
    public void CanAddAlarm()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var alarm = personalManager.CreateNewAlarm(time);
        bool alarmAdded = personalManager.AddAlarmToDay(alarm);
        Assert.True(alarmAdded);
    }
    [Fact]
    public void CannotAddDuplicateAlarm()
    {
        var day = new DateOnly(2024, 2, 8);
        var time = new TimeOnly(3, 2, 9);
        var alarm = personalManager.CreateNewAlarm(time);
        bool alarmAdded = personalManager.AddAlarmToDay(alarm, day);
        bool duplicateAlarmAdded = personalManager.AddAlarmToDay(alarm, day);
        Assert.False(duplicateAlarmAdded);
    }
}