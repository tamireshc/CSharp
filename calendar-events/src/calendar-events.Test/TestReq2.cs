using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq2
{
    [Theory(DisplayName = "Deve procurar um evento por titulo")]
    [InlineData("comprar pão", "10/10/2022", "na padaria", 0)]
    public void TestListSearchByTitle(string title, string date, string description, int expected)
    {
        var eventListInstance = new EventList();
        eventListInstance.Add(new Event(title, date, description));
        var resultIndexTitle = eventListInstance.SearchByTitle(title);
        resultIndexTitle.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve procurar um evento por data")]
    [InlineData("comprar pão", "10/10/2022", "na padaria", 0)]
    public void TestListSearchByDate(string title, string date, string description, int expected)
    {
        var eventListInstance = new EventList();
        eventListInstance.Add(new Event(title, date, description));
        var resultIndexDate = eventListInstance.SearchByDate(date);
        resultIndexDate.Should().Be(expected);
    }


}