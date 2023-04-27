using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
  public readonly IRecipeService _service;

  public RecipesController(IRecipeService service)
  {
    this._service = service;
  }

  //Read
  [HttpGet]
  public IActionResult Get()
  {
    var allRecipes = _service.GetRecipes();
    return Ok(allRecipes);
  }

  //Read
  [HttpGet("{name}", Name = "GetRecipe")]
  public IActionResult Get(string name)
  {
    var recipe = _service.GetRecipe(name);
    if (recipe == null) return NotFound();
    return Ok(recipe);
  }

  [HttpPost]
  public IActionResult Create([FromBody] Recipe recipe)
  {
    if (recipe == null) return BadRequest();
    _service.AddRecipe(recipe);
    return CreatedAtRoute("/", recipe);
  }

  [HttpPut("{name}")]
  public IActionResult Update(string name, [FromBody] Recipe recipe)
  {
    if (recipe == null) return BadRequest();
    if (recipe.Name.ToLower() != name.ToLower()) return BadRequest();
    _service.UpdateRecipe(recipe);
    return NoContent();
  }

  [HttpDelete("{name}")]
  public IActionResult Delete(string name)
  {
    var isRecipeExists = _service.RecipeExists(name);
    if (isRecipeExists == null) return NotFound();
    _service.DeleteRecipe(name);
    return NoContent();
  }
}
