using Microsoft.AspNetCore.Mvc;

using WebAPI.Data.Entities;

namespace WebAPI.Services.CharacterService
{
    public interface ICharacterService
    {   
        Task<ActionResult<IEnumerable<Character>>> GetCharacters();

        Task<ActionResult<Character>> GetCharacter(int id);

        Task<IActionResult> PutCharacter(int id, Character character);

        Task<ActionResult<Character>> PostCharacter(Character character);

        Task<IActionResult> DeleteCharacter(int id);

        bool CharacterExists(int id);
    }
}