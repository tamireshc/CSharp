using pokedex.Models;
using pokedex.Controllers;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using AutoBogus;
using pokedex.Core;
using Moq;
// using pokemon.Test;
using FluentAssertions;

namespace pokedex.Test
{
    public class PokemonsControllerTest
    {

        private Mock<IPokemonService> _serviceMock;
        public PokemonsControllerTest()
        {
            _serviceMock = new Mock<IPokemonService>();
        }

        // Testes GET
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var serviceInstance = new PokemonService();
            var controllerInstance = new PokemonsController(serviceInstance);
            var result = controllerInstance.Get();
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllPokemons()
        {
            var pokemons = AutoFaker.Generate<Pokemon>(2);
            _serviceMock.Setup(p => p.GetAllItems()).Returns(pokemons);

            var controllerInstance = new PokemonsController(_serviceMock.Object);
            var result = controllerInstance.Get().Result as OkObjectResult;
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var serviceInstance = new PokemonService();
            var controllerInstance = new PokemonsController(serviceInstance);
            var result = controllerInstance.GetById(999999999);
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var pokemon = AutoFaker.Generate<Pokemon>(1)[0];
            _serviceMock.Setup(p => p.GetById(1)).Returns(pokemon);

            var controllerInstance = new PokemonsController(_serviceMock.Object);
            var result = controllerInstance.GetById(1);
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var pokemon = AutoFaker.Generate<Pokemon>(1)[0];
            _serviceMock.Setup(p => p.GetById(1)).Returns(pokemon);

            var controllerInstance = new PokemonsController(_serviceMock.Object);
            var result = controllerInstance.GetById(1).Result as OkObjectResult;
            result.Value.Should().BeEquivalentTo(pokemon);
        }

        // Testes POST
        [Fact]
        public void Add_PokemonWithoutId_ReturnsBadRequest()
        {
            var pokemonWithoutId = new Pokemon() { Name = "Bulbao", Type = "Grass" };
            var pokemonService = new PokemonService();
            var controllerInstance = new PokemonsController(pokemonService);
            var result = controllerInstance.Post(pokemonWithoutId);
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnsCreatedResponse()
        {
            var pokemon = new Pokemon() { Id = 1, Name = "Bulbao", Type = "Grass" };
            var pokemonService = new PokemonService();
            var controllerInstance = new PokemonsController(pokemonService);
            var result = controllerInstance.Post(pokemon);
            result.Should().BeOfType<OkObjectResult>(); ;
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnedResponseHasCreatedItem()
        {
            var pokemon = new Pokemon() { Id = 1, Name = "Bulbao", Type = "Grass" };
            var pokemonService = new PokemonService();
            var controllerInstance = new PokemonsController(pokemonService);
            var result = controllerInstance.Post(pokemon) as OkObjectResult;
            result.Value.Should().Be(true);
        }

        // Testes PUT
        [Fact]
        public void PutById_ExistingIdPassed_ReturnsOkResult()
        {
            var pokemonEdit = AutoFaker.Generate<Pokemon>(1)[0];

            var pokemonService = new PokemonService();
            var controllerInstance = new PokemonsController(pokemonService);

            var result = controllerInstance.Put(25, pokemonEdit) as OkObjectResult;
            result.Value.Should().Be(true);
        }

        [Fact]
        public void PutById_IdNotFound_ReturnsNotFoundResult()
        {
            var pokemon = AutoFaker.Generate<Pokemon>(1)[0];
            _serviceMock.Setup(p => p.Put(99999, pokemon)).Returns(false);

            var controllerInstance = new PokemonsController(_serviceMock.Object);
            var result = controllerInstance.Put(99999, pokemon);
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        // Testes DELETE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            _serviceMock.Setup(p => p.Remove(99999)).Returns(false);
            var controllerInstance = new PokemonsController(_serviceMock.Object);

            var result = controllerInstance.Remove(99999);
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            _serviceMock.Setup(p => p.Remove(99999)).Returns(true);
            var controllerInstance = new PokemonsController(_serviceMock.Object);

            var result = controllerInstance.Remove(99999);
            result.Should().BeOfType<OkObjectResult>();
        }

    }
}