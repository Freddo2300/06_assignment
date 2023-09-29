using WebAPI.Data.Entities;

namespace WebAPI.Services.FranchiseService
{
    public interface IFranchiseService
    {
        Task<bool> FranchiseExists(int id);

        Task<ICollection<Franchise>> GetFranchises();

        Task<Franchise> GetFranchiseById(int id);

        // Create
        Task<Franchise> CreateFranchise(Franchise franchise);

        // Update
        Task UpdateFranchise(Franchise franchise);

        // Delete
        Task DeleteFranchise(int id);
    }
}