using Microsoft.EntityFrameworkCore;

namespace Sharpi
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PokemonId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Type { get; set; }
        
    }

    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=PokemonDb;Integrated Security=True");
        }
    }
}
