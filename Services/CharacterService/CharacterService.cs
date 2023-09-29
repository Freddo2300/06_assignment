using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly WebApiDbContext _context;

        public async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(c => c.Id == id);
        }

        public async Task<Character> GetCharacterById(int id)
        {   
            if (!await CharacterExists(id))
            {
                throw new Exception(message: "No character by that id");
            }

            Character character 
                = await _context.Characters
                    .Where(c => c.Id == id).SingleOrDefaultAsync() ?? throw new Exception("Could not find character");

            return character;
        }

        public async Task<ICollection<Character>> GetCharacters()
        {
            throw new NotImplementedException();
        }

        public async Task<Character> CreateCharacter(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            
            return character;
        }

        public async Task UpdateCharacter(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteCharacter(int id)
        {
            if (!await CharacterExists(id))
                throw new Exception("No character with that id");

            Character character = await GetCharacterById(id);

            _context.Remove(character);

            await _context.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Character>>> ICharacterService.GetCharacters()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Character>> GetCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutCharacter(int id, Character character)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Character>> PostCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> ICharacterService.DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }

        bool ICharacterService.CharacterExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}