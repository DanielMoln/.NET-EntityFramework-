using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetRelations.Data;
using NetRelations.DTOs;
using NetRelations.Models;

namespace NetRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TluController : ControllerBase
    {
        private readonly DataContext _context;

        public TluController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };

            var backpack = new Backpack
            {
                Description = request.BackpackCreate.Description,
                Character = newCharacter
            };
            var weapons = request.weapons.Select(w => new Weapon
            {
                Name = w.name,
                Character = newCharacter
            }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters
                .Include(
                    c => c.Backpack
                )
                .Include(
                    c => c.Weapons
                )
                .ToListAsync());
        }
    }
}
