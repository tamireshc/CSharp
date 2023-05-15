using Microsoft.AspNetCore.Mvc;
using LoggingIn.Core;
using LoggingIn.Requests;
using LoggingIn.Repositories;

namespace LoggingIn.Controllers;

[ApiController]
[Route("animals")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _repository;
    private readonly ILogger<AnimalController> _logger;

    public AnimalController(IAnimalRepository repository, ILogger<AnimalController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var animals = _repository.GetAll();
            _logger.Log(LogLevel.Information, $"GetAll executed with {animals.Count()} animals");
            return Ok(animals);

        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, $"{ex.Message} GetAll failed");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult GetById(int id)
    {
        try
        {
            var animal = _repository.GetById(id);

            if (animal == null)
            {
                _logger.Log(LogLevel.Warning, $"GetById failed: the animal with id {id} was not found");
                return NotFound("Animal not found");
            };
            _logger.Log(LogLevel.Information, $"GetById executed with id {id}");
            return Ok(animal);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, $"{ex.Message} GetById failed");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost]
    public ActionResult Create(AnimalRequest request)
    {
        try
        {
            var id = _repository.GetNextIdValue();

            var animal = new Animal(id, request);
            _repository.Create(animal);

            _logger.Log(LogLevel.Information, $"Create executed with id {id}");
            return CreatedAtAction("GetById", new { id = animal.Id }, animal);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, $"{ex.Message} Create failed");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, AnimalRequest request)
    {
        try
        {
            var didUpdate = _repository.Update(id, new
            {
                Name = request.Name,
                Species = request.Species,
                UpdatedAt = DateTime.Now
            });

            if (!didUpdate)
            {
                _logger.Log(LogLevel.Warning, $"Update failed: The animal with id {id} was not found");
                return NotFound("Animal not found");
            }
            _logger.Log(LogLevel.Information, $"Update executed with id {id}");
            return Ok($"Animal {id} updated");
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, $"{ex.Message} Update failed");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var didDelete = _repository.Delete(id);

            if (!didDelete)
            {
                _logger.Log(LogLevel.Warning, $"Delete failed: The animal with id {id} was not found");
                return NotFound("Animal not found");
            }
            _logger.Log(LogLevel.Information, $"Delete executed with id {id}");
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, $"{ex.Message} Delete failed");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
