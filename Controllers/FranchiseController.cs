using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Services.FranchiseService;
using WebAPI.Data.DTO.FranchiseDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private IFranchiseService franchiseService;

        public FranchiseController(WebApiDbContext context)
        {
            _context = context;
            franchiseService = new FranchiseService(_context);

        }

        // GET: api/Franchise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            FranchiseDTO currentDTO;
            var franchises = await franchiseService.GetFranchises();
            List<FranchiseDTO> franchisesDTO = new List<FranchiseDTO>();

            foreach (Franchise franchise in franchises) {
                currentDTO = new FranchiseDTO();
                currentDTO.Id = franchise.Id;
                currentDTO.Name = franchise.Name;
                currentDTO.Description = franchise.Description;

                franchisesDTO.Add(currentDTO);
            }

            return franchises is null ? NotFound() : franchisesDTO;
        }

        // GET: api/Franchise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            var franchise = await franchiseService.GetFranchiseById(id);
            FranchiseDTO franchiseDTO = new FranchiseDTO();

            franchiseDTO.Id = franchise.Id;
            franchiseDTO.Name = franchise.Name;
            franchiseDTO.Description = franchise.Description;
            return franchise is null ? NotFound() : franchiseDTO;
        }

        // PUT: api/Franchise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            

            bool checkFound = await franchiseService.UpdateFranchise(franchise);

            if (!checkFound) {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Franchise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FranchisePostDTO>> PostFranchise(Franchise franchise)
        {

            var working = await franchiseService.CreateFranchise(franchise);
            if (!working)
            {
                return Problem("Entity set 'WebApiDbContext.Franchises'  is null.");
            }

            FranchisePostDTO franchiseDTO = new();

            franchiseDTO.Name = franchise.Name;
            franchiseDTO.Id = franchise.Description;

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchiseDTO);
        }

        // DELETE: api/Franchise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            bool working = await franchiseService.DeleteFranchise(id);
            if (!working) {
                return NotFound();
            }
            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return franchiseService.FranchiseExists(id);//(_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
