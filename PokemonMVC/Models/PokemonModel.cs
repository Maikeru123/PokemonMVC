using System.Collections.Generic;

namespace PokemonMVC.Models
{
    public class PokemonModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    public class PokemonApiResponse
    {
        public List<PokemonModel> Results { get; set; }
    }
}
