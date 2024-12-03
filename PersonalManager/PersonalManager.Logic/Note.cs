namespace PersonalManager.Logic;

public class Note : ICalendarItem
{
    private DateOnly _dateCreated{get;}
    public string _content{get;}   

    public Note(string notesContent, DateOnly dateCreated)
    {
        _content = notesContent;
        _dateCreated = dateCreated;
    

}