using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public FranchiseController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Franchise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
          if (_context.Franchises == null)
          {
              return NotFound();
          }
            return await _context.Franchises.Include(f => f.Movies).ToListAsync();
        }

        // GET: api/Franchise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
          if (_context.Franchises == null)
          {
              return NotFound();
          }
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
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

            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Franchise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
          if (_context.Franchises == null)
          {
              return Problem("Entity set 'WebApiDbContext.Franchises'  is null.");
          }
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return (_context.Franchises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}