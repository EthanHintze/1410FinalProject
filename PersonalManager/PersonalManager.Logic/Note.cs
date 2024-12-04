namespace PersonalManager.Logic;

public class Note : ICalendarItem
{
    private DateOnly _dateCreated{get;}
    private string _content{get;}   
    public DateOnly dateCreated{get{return _dateCreated;}}

    public Note(string notesContent, DateOnly dateCreated)
    {
        _content = notesContent;
        _dateCreated = dateCreated;
    }

}