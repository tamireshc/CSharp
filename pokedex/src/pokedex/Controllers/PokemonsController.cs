using pokedex.Models;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using pokedex.Core;

namespace pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        public IPokemonService Service;
        public PokemonsController(IPokemonService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<List<Pokemon>> Get()
        {
            var result = Service.GetAllItems();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> GetById(int id)
        {
            var result = Service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Pokemon newPokemon)
        {
            if (newPokemon.Id == null) return BadRequest();


            var result = Service.Post(newPokemon);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Put(int id, Pokemon pokemon)
        {
            var result = Service.Put(id, pokemon);
            if (!result) return NotFound("Pokemon not found");
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var result = Service.Remove(id);
            if (!result) return NotFound("Pokemon not found");
            return Ok(result);
        }
    }
}