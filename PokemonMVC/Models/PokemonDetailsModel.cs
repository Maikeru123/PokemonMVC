namespace PokemonMVC.Models
{
    public class PokemonDetailsModel
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Sprites Sprites { get; set; }
    }

    public class Sprites
    {
        public string Front_Default { get; set; }
    }
}

