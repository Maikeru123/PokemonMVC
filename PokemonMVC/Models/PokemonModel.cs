using System.Collections.Generic;

namespace PokemonMVC.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    // Add this class
    public class PokemonApiResponse
    {
        public List<PokemonModel> Results { get; set; }
    }
}
