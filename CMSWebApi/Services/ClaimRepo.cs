using CMSWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSWebApi.Services
{
    public class ClaimRepo : IRepo<int, Claim>
    {
        private readonly ClaimContext _context;

        public ClaimRepo(ClaimContext context)
        {
            _context = context;
        }
        public Claim Add(Claim item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public Claim Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Claim Get(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Claim> GetAll()
        {
            if (_context != null)
            {
                return _context.claim.ToList();
            }
            return null;
        }

        public ICollection<Claim> GetAllPlansByMember()
        {
            throw new NotImplementedException();
        }

        public Claim Update(Claim item)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlans(int pId, Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
