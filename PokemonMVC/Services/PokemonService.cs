using Newtonsoft.Json;
using PokemonMVC.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonMVC.Services
{
    public class PokemonService
    {
        private readonly string apiUrl = "https://pokeapi.co/api/v2/pokemon?limit=20";

        // Fetch List of Pokémon
        public async Task<List<PokemonModel>> GetPokemonListAsync()
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var apiResponse = JsonConvert.DeserializeObject<PokemonApiResponse>(response.Content);
                return apiResponse?.Results ?? new List<PokemonModel>();
            }

            return new List<PokemonModel>();
        }

        // Fetch Pokémon Details
        public async Task<PokemonDetailsModel> GetPokemonDetailsAsync(string name)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{name}");
            var request = new RestRequest();
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<PokemonDetailsModel>(response.Content);
            }

            return null;
        }
    }
}
