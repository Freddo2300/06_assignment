using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly WebApiDbContext _context;

        public CharacterService(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            if (_context.Characters == null)
                throw new Exception("No characters found");

            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }

        public async Task<Character> GetCharacter(int id)
        {   
            if (!await CharacterExists(id))
            {
                throw new Exception(message: "No character by that id");
            }

            Character character 
                = await _context.Characters
                    .Where(c => c.Id == id)
                    .Include(c => c.Movies)
                    .SingleOrDefaultAsync() ?? throw new Exception("Could not find character");

            return character;
        }

        public async Task<Character> PostCharacter(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            
            return character;
        }

        public async Task<Character> PutCharacter(Character character)
        {
            //character.Movies.Clear();

            _context.Entry(character).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return character;
        }

        public async Task DeleteCharacter(int id)
        {
            if (!await CharacterExists(id))
                throw new Exception("No character with that id");

            Character character = await GetCharacter(id);

            character.Movies.Clear();

            _context.Remove(character);

            await _context.SaveChangesAsync();
        }

    }
}