namespace random_meal.Services
{
  public interface IRandomMealService
  {
    Task<object> GetRandomMeal();
  }
}
