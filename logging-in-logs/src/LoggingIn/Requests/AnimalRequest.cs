using System.Text.Json.Serialization;
using LoggingIn.Core;

namespace LoggingIn.Requests;

public class AnimalRequest
{
    public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Species Species { get; set; }
}