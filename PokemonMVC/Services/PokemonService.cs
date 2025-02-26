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

        public async Task<List<PokemonModel>> GetPokemonListAsync()
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful) return new List<PokemonModel>();

            var apiResponse = JsonConvert.DeserializeObject<PokemonApiResponse>(response.Content);
            var pokemonList = new List<PokemonModel>();

            foreach (var item in apiResponse.Results)
            {
                var details = await GetPokemonDetailsAsync(item.Url);
                pokemonList.Add(details);
            }

            return pokemonList;
        }

        private async Task<PokemonModel> GetPokemonDetailsAsync(string pokemonUrl)
        {
            var client = new RestClient(pokemonUrl);
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful) return new PokemonModel();

            var data = JsonConvert.DeserializeObject<PokemonDetailsResponse>(response.Content);

            return new PokemonModel
            {
                Name = data.Name,
                ImageUrl = data.Sprites.FrontDefault,
                Height = data.Height,
                Weight = data.Weight
            };
        }
    }

    public class PokemonApiResponse
    {
        public List<PokemonResult> Results { get; set; }
    }

    public class PokemonResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonDetailsResponse
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PokemonSprites Sprites { get; set; }
    }

    public class PokemonSprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
    }
}
