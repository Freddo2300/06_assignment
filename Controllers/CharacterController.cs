using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Data.DTO.CharacterDTO;
using WebAPI.Services.CharacterService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;
        
        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all characters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            return Ok(
                _mapper.Map<IEnumerable<CharacterDTO>>(
                    await _characterService.GetCharacters()
                ));
        }

        /// <summary>
        /// Get single character by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            return Ok(
                _mapper.Map<CharacterDTO>(
                    await _characterService.GetCharacter(id)
                ));
        }

        /// <summary>
        /// Update character
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Character>> PutCharacter(int id, CharacterPutDTO characterDTO)
        {   
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }


            return Ok(
                await _characterService.PutCharacter(_mapper.Map<Character>(characterDTO))
            );
        }

        /// <summary>
        /// Create new character
        /// </summary>
        /// <param name="characterDTO"></param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterPostDTO characterDTO)
        {
            return Ok(
                await _characterService.PostCharacter(_mapper.Map<Character>(characterDTO))
            );
        }

        /// <summary>
        /// Delete character
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            await _characterService.DeleteCharacter(id);
            
            return Ok();
        }
    }
}