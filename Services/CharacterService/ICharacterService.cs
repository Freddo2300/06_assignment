using Microsoft.AspNetCore.Mvc;

using WebAPI.Data.Entities;

namespace WebAPI.Services.CharacterService
{
    public interface ICharacterService
    {   
        Task<IEnumerable<Character>> GetCharacters();

        Task<Character> GetCharacter(int id);

        Task<Character> PutCharacter(Character character);

        Task<Character> PostCharacter(Character character);

        Task DeleteCharacter(int id);

        Task<bool> CharacterExists(int id);
    }
}