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

        public async Task<IActionResult> Index()
        {
            var pokemonList = await _pokemonService.GetPokemonListAsync();
            return View(pokemonList);
        }
    }
}
