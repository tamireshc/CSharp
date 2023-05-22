namespace university_applications.Services
{
  public class UniversityService : IUniversityService
  {
    private readonly HttpClient _client;
    private string _baseUrl = "http://universities.hipolabs.com";
    public UniversityService(HttpClient client)
    {
      _client = client;
      _client.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<object> FindUniversity(string name, string country)
    {
      var response = await _client.GetAsync($"search?name={name}&country={country}");
      if (!response.IsSuccessStatusCode)
      {
        return default;
      }
      var responseJson = await response.Content.ReadFromJsonAsync<object>();
      return responseJson;
    }

    public async Task<object> FindUniversity(string country)
    {
      var response = await _client.GetAsync($"search?country={country}");
      if (!response.IsSuccessStatusCode)
      {
        return default;
      }
      var responseJson = await response.Content.ReadFromJsonAsync<object>();
      return responseJson;
    }
  }
}
