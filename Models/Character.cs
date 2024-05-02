using System.Text.Json.Serialization;

namespace NetRelations.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Backpack Backpack { get; set; }
        [JsonIgnore]
        public List<Weapon> Weapons { get; set; }
        [JsonIgnore]
        public List<Faction> Factions { get; set; }
    }
}
