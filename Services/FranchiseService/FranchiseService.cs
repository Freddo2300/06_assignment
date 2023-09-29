using WebAPI.Data.Entities;
using WebAPI.Exceptions;
using WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.FranchiseService
{
    public class FranchiseService : IFranchiseService
    {
        private readonly WebApiDbContext _context;

        public FranchiseService( WebApiDbContext context ){
            this._context = context;
        }
        public bool FranchiseExists(int id)
        {
            return (_context.Franchises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<ActionResult<Franchise>> GetFranchiseById(int id)
        {
            if (_context.Franchises == null)
            {
                return null;
            }
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return null;
            }
            return franchise;
        }

        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            if (_context.Franchises == null)
          {
              return null;
          }
            return await _context.Franchises.ToListAsync();
        }

        public async Task<bool> CreateFranchise(Franchise franchise)
        {
            if (_context.Franchises == null)
          {
              return false;
          }
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return true; //CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        public async Task<bool> UpdateFranchise(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                if (!FranchiseExists(franchise.Id))
                {
                    return false;
                }
                else
                {
                    throw new FranchiseException("FAILED");
                }
            }

            return true;
        }

        public async Task<bool> DeleteFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return false;
            }
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return false;
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}