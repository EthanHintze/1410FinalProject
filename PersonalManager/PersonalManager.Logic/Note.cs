namespace PersonalManager.Logic;
//(REQ#2.2.1)
public class Note : ICalendarItem
{
    private DateOnly _dateCreated{get;}
    private string _content{get;}   
    public DateOnly dateCreated{get{return _dateCreated;}}
    public string CalendarText
    {
        get
        {
            return $"-Note- {_content}";
        }
    }

    public Note(string notesContent, DateOnly dateCreated)
    {
        _content = notesContent;
        _dateCreated = dateCreated;
    }

}