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
        bool scheduleAdded = personalManager.AddNewDailySchedule(NewDailySchedule);
        Assert.True(scheduleAdded);
    }
    [Fact]
    void CannotAddDuplicateSchedules()
    {
        var NewDay = new DateOnly(2024, 2, 8);
        var NewDailySchedule = new DailyCalendar(NewDay);
        bool scheduleAdded = personalManager.AddNewDailySchedule(NewDailySchedule);
        bool scheduleAddedAgain = personalManager.AddNewDailySchedule(NewDailySchedule);
        Assert.False(scheduleAddedAgain);
    }
}