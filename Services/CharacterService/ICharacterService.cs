using WebAPI.Data.Entities;

namespace WebAPI.Services.CharacterService
{
    public interface ICharacterService
    {   
        Task<bool> CharacterExists(int id);

        Task<ICollection<Character>> GetCharacters();

        Task<Character> GetCharacterById(int id);

        Task<Character> CreateCharacter(Character character);

        Task UpdateCharacter(Character character);

        Task DeleteCharacter(int id);
    }
}