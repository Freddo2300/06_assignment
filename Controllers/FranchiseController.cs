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
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            var franchises = await franchiseService.GetFranchises();
            return franchises is null ? NotFound() : franchises;
        }

        // GET: api/Franchise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await franchiseService.GetFranchiseById(id);

            return franchise is null ? NotFound() : franchise;
        }

        // PUT: api/Franchise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
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
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {

            var working = await franchiseService.CreateFranchise(franchise);
            if (!working)
            {
                return Problem("Entity set 'WebApiDbContext.Franchises'  is null.");
            }

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
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
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
