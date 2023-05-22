using Microsoft.AspNetCore.Mvc;
using university_applications.Services;

namespace university_applications.Controllers
{
  [ApiController]
  [Route("university")]
  public class UniversityController : ControllerBase, IUniversityController
  {
    private IUniversityService _universityService;
    public UniversityController(IUniversityService universityService)
    {
      _universityService = universityService;
    }
    [HttpGet("{country}/{name}")]
    public async Task<IActionResult> FindUniversity(string country, string name)
    {
      var universities = await _universityService.FindUniversity(name, country);
      if (universities.ToString() == "[]") return BadRequest();
      return Ok(universities);
    }
    [HttpGet("{country}")]
    public async Task<IActionResult> FindUniversity(string country)
    {
      var universities = await _universityService.FindUniversity(country);
      if (universities.ToString() == "[]") return BadRequest();
      return Ok(universities);
    }
  }
}
