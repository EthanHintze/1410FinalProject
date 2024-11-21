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
}