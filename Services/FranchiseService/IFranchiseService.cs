using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;

namespace WebAPI.Services.FranchiseService
{
    public interface IFranchiseService
    {
        bool FranchiseExists(int id);

        Task<ActionResult<IEnumerable<Franchise>>> GetFranchises();

        Task<ActionResult<Franchise>> GetFranchiseById(int id);

        // Create
        Task<bool> CreateFranchise(Franchise franchise);

        // Update
        Task<bool> UpdateFranchise(Franchise franchise);

        // Delete
        Task<bool> DeleteFranchise(int id);
    }
}