using Microsoft.AspNetCore.Mvc;
using pet_care.Repository;
using pet_care.Models;


namespace pet_care.Controllers
{
  [ApiController]
  [Route("api")]
  public class PerController : Controller
  {
    private readonly BaseRepository _repository;
    public PerController(BaseRepository repository)
    {
      _repository = repository;
    }

    /// <summary> This function create a new appointment</summary>
    /// <param name="appointment"> an appointment instance</param>
    /// <returns> an appointment</returns>
    [HttpPost("Appointment")]
    public IActionResult PostAppointment(Appointment appointment)
    {
      _repository.Add(appointment);
      return Ok();
    }
  }
}