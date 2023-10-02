using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Services.FranchiseService;
using WebAPI.Data.DTO.FranchiseDTO;
using WebAPI.Data.DTO;
using WebAPI.MappingProfiles;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private IFranchiseService franchiseService;

        private readonly IMapper _mapper;
        public FranchiseController(WebApiDbContext context, IMapper mapper)
        {
            _context = context;
            franchiseService = new FranchiseService(_context);
            _mapper = mapper;            
        }

        /// <summary>
        /// Get all franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            return Ok(
                _mapper.Map<IEnumerable<FranchiseDTO>>(
                    await franchiseService.GetFranchises()
                ));           
        }

        /// <summary>
        /// Get a single franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            return Ok(
                _mapper.Map<FranchiseDTO>(
                    await franchiseService.GetFranchiseById(id)
                ));
        }

        /// <summary>
        /// Update a single franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            
            return Ok(
                await franchiseService.UpdateFranchise(_mapper.Map<Franchise>(franchise))
            );
            

            // if (!checkFound) {
            //     return NotFound();
            // }

            // return NoContent();
        }

        /// <summary>
        /// Create a new franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FranchisePostDTO>> PostFranchise(FranchisePostDTO franchise)
        {


            return Ok(
                await franchiseService.CreateFranchise(_mapper.Map<Franchise>(franchise))
            );

            // var working = await franchiseService.CreateFranchise(franchise);
            // if (!working)
            // {
            //     return Problem("Entity set 'WebApiDbContext.Franchises'  is null.");
            // }



            // return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchiseDTO);
        }

        /// <summary>
        /// Delete a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            bool working = await franchiseService.DeleteFranchise(id);
            if (!working) {
                return NotFound();
            }
            return Ok();
        }

        private bool FranchiseExists(int id)
        {
            return franchiseService.FranchiseExists(id);//(_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
