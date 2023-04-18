using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pokedex.Core;

namespace pokedex.Services
{
    public interface IPokemonService
    {

        public List<Pokemon> GetAllItems();

        public Pokemon? GetById(int id);

        public bool Add(Pokemon pokemon);

        public bool Put(int id, Pokemon pokemon);

        public bool Remove(int id);

        public bool Post(Pokemon newPokemon);

    }
}
