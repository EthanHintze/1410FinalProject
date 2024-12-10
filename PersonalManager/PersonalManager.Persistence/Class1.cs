using System.Text.Json;
namespace PersonalManager.Persistence;
//(REQ#4.1.1)
//I couldn't get it to work
public class Persistence
{
    public static void CreateFile()
    {
        string fileName = "CalendarData.json";
        File.Create(fileName);
    }
    public static void PopulateFile()
    {
        //string jsonString = JsonSerializer.Serialize()
    }

}
