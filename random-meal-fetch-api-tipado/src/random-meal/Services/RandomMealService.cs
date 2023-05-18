namespace random_meal.Services
{

  public class RandomMealService : IRandomMealService
  {
    private readonly HttpClient _client;
    private const string _baseUrl = "https://www.themealdb.com/api/json/v1/";

    public RandomMealService(HttpClient client)
    {
      _client = client;
    }

    /// <summary> This function get a random recipe from service</summary>
    /// <returns> a object</returns>
    public async Task<object?> GetRandomMeal()
    {
      var response = await _client.GetAsync($"{_baseUrl}1/random.php");
      if (!response.IsSuccessStatusCode)
      {
        return default;
      }
      var responseJson = await response.Content.ReadFromJsonAsync<object>();
      return responseJson;
    }
  }
}