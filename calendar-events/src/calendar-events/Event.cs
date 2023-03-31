using System.Globalization;
namespace calendar_events;

public class Event : IEvent
{
    public string? Title { get; set; }
    public DateTime EventDate { get; set; }
    public string? Description { get; set; }


    public Event(string title, string date, string description)
    {
        Title = title;
        EventDate = DateTime.Parse(date);
        Description = description;
    }

    public Event(string title, string date)
    {
        Title = title;
        EventDate = DateTime.Parse(date);
    }

    public void DelayDate(int days)
    {
        EventDate = EventDate.AddDays(days);
    }

    public string PrintEvent(string format)
    {
        if (format == "detailed") return $"Evento = {Title}\nDate = {EventDate:d}\nDescription = {Description}";

        else return $"Evento = {Title}\nDate = {EventDate:d}\n";


    }
}
