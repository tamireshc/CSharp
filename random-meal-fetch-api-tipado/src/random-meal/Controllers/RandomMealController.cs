using Microsoft.AspNetCore.Mvc;
using random_meal.Services;

namespace random_meal.Controllers;

[ApiController]
[Route("meal")]
public class RandomMealController : ControllerBase
{
  private readonly IRandomMealService _randomMealService;

  public RandomMealController(IRandomMealService randomMealService)
  {
    _randomMealService = randomMealService;
  }

  [HttpGet]
  public async Task<IActionResult> GetRandomMeal()
  {
    var meal = await _randomMealService.GetRandomMeal();
    if (meal == null) return NotFound();
    return Ok(meal);
  }
}
