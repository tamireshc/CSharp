using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq1
{
    [Theory(DisplayName = "Deve cadastrar um evento com o construtor completo")]
    [InlineData("comprar pão", "10/10/2022", "na padaria")]
    public void TestEventFullConstructor(string title, string date, string description)
    {
        var eventInstance = new Event(title, date, description);
        eventInstance.Title.Should().Be(title);
        eventInstance.EventDate.Should().Be(DateTime.Parse(date));
        eventInstance.Description.Should().Be(description);
    }

    [Theory(DisplayName = "Deve cadastrar um evento com o construtor sem descrição")]
    [InlineData("comprar pão", "10/10/2022")]
    public void TestEventHalfConstructor(string title, string date)
    {
        var eventInstance = new Event(title, date);
        eventInstance.Title.Should().Be(title);
        eventInstance.EventDate.Should().Be(DateTime.Parse(date));

    }

    [Theory(DisplayName = "Deve atrasar a data de um evento corretamente")]
    [InlineData("comprar pão", "11/10/2022", 10, "21/10/2022")]
    public void TestEventDelayDate(string title, string date, int days, string expected)
    {
        var eventInstance = new Event(title, date);
        eventInstance.DelayDate(days);
        eventInstance.EventDate.Should().Be(DateTime.Parse(expected));

    }

    [Theory(DisplayName = "Deve imprimir um evento corretamente")]
    [InlineData("comprar pão", "10/10/2022", "na padaria", "detailed", "Evento = comprar pão\nDate = 10/10/2022\nDescription = na padaria")]
    [InlineData("comprar pão", "10/10/2022", "na padaria", "normal", "Evento = comprar pão\nDate = 10/10/2022\n")]

    public void TestPrintEvent(string title, string date, string description, string format, string expected)
    {
        var eventInstance = new Event(title, date, description);
        var printResult = eventInstance.PrintEvent(format);
        printResult.Should().Be(expected);
    }


}