using Microsoft.EntityFrameworkCore;
using NetRelations.Models;

namespace NetRelations.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : 
            base(options)
        { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }

        // public record struct CharacterCreateDto(string Name, BackpackCreateDto Backpack);
    }
}
