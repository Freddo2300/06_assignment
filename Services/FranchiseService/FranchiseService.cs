using WebAPI.Data.Entities;

namespace WebAPI.Services.FranchiseService
{
    public class FranchiseService : IFranchiseService
    {
        public Task<bool> FranchiseExists(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Franchise> GetFranchiseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Franchise>> GetFranchises()
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> CreateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFranchise(int id)
        {
            throw new NotImplementedException();
        }
    }
}