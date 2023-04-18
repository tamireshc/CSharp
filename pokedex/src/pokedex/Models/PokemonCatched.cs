using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokedex.Core;

namespace pokedex.Models
{
    public class PokemonCatched
    {
        public List<Pokemon> pokemons;
        public PokemonCatched()
        {
            pokemons = new List<Pokemon>()
        {
            new Pokemon(){
            Id= 25,
            Name= "pikachu",
            Type= "electric",
            Weight= 60,
            }
        };

        }

        public List<Pokemon> GetAll()
        {
            return pokemons;
        }

        public Pokemon? GetById(int id)
        {
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Id == id) return pokemon;

            }
            return null;
        }

        public bool Created(Pokemon newPokemon)
        {
            pokemons.Add(newPokemon);
            return true;
        }

        public bool Put(int id, Pokemon pokemon)
        {
            foreach (var pokemonItem in pokemons)
            {
                if (pokemonItem.Id == id)
                {
                    var index = pokemons.IndexOf(pokemonItem);
                    pokemons[index] = pokemon;
                    return true;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            foreach (var pokemonItem in pokemons)
            {
                if (pokemonItem.Id == id)
                {
                    pokemons.Remove(pokemonItem);
                    return true;
                }
            }
            return false;

        }

    }
}
