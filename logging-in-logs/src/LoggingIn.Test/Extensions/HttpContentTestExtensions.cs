using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoggingIn.Test.Extensions;

static class HttpContentTestExtensions
{
    internal static Task<T?> ReadFromJsonWithEnumAsync<T>(this HttpContent content)
    {
        return content.ReadFromJsonAsync<T>(
            new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            }
        );
    }
}