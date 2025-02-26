using Microsoft.AspNetCore.Mvc;
using PokemonMVC.Models;
using PokemonMVC.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PokemonMVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController()
        {
            _pokemonService = new PokemonService();
        }

        // List of Pokémon
        public async Task<IActionResult> Index()
        {
            var pokemonList = await _pokemonService.GetPokemonListAsync();
            return View(pokemonList);
        }

        // Pokémon Details Page
        public async Task<IActionResult> Details(string name)
        {
            var pokemon = await _pokemonService.GetPokemonDetailsAsync(name);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }
    }
}
