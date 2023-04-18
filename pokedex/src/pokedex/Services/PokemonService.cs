using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokedex.Core;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        public bool Add(Pokemon newPokemon)
        {
            var modelPokemon = new PokemonCatched();
            var result = modelPokemon.Created(newPokemon);
            return result;

        }
        public List<Pokemon> GetAllItems()
        {
            var modelPokemon = new PokemonCatched();
            var result = modelPokemon.GetAll();
            return result;
        }
        public Pokemon? GetById(int id)
        {
            var modelPokemon = new PokemonCatched();
            var result = modelPokemon.GetById(id);
            return result;
        }

        public bool Post(Pokemon newPokemon)
        {
            var modelPokemon = new PokemonCatched();
            var result = modelPokemon.Created(newPokemon);
            return result;
        }
        public bool Put(int id, Pokemon pokemon)
        {
            var modelPokemom = new PokemonCatched();
            var result = modelPokemom.Put(id, pokemon);
            return result;
        }
        public bool Remove(int id)
        {
            var modelPokemom = new PokemonCatched();
            var result = modelPokemom.Delete(id);
            return result;
        }
    }
}
