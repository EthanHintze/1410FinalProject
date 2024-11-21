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
        var Day = new DateOnly(2024, 2, 8);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", Day);
        bool taskAdded = personalManager.AddTaskToDay(task);
        Assert.True(taskAdded);
    }
    public void CanAddTaskToDayNonexistingDay()
    {
        var NewDay = new DateOnly(2024, 2, 9);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", NewDay);
        bool taskAdded = personalManager.AddTaskToDay(task);
        Assert.True(taskAdded);
    }
    public void CannotAddDuplicateTasks()
    {
        var Day = new DateOnly(2024, 2, 8);
        var task = personalManager.CreateNewTask("Clean", "Clean the kitchen", Day);
        bool taskAdded = personalManager.AddTaskToDay(task);
        Assert.False(taskAdded);
    }
}