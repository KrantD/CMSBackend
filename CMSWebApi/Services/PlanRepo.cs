using CMSWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSWebApi.Services
{
    public class PlanRepo : IRepo<int, Plan>
    {
        private readonly ClaimContext _context;

        public PlanRepo(ClaimContext context)
        {
            _context = context;
        }
        public Plan Add(Plan item)
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

        public Plan Get(int key)
        {
            var pln = _context.plans.FirstOrDefault(e => e.pId == key);
            if (pln != null)
            {
                try
                {
                    return pln;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }

        [HttpGet]
       
        public Plan Update(Plan item)
        {
            var plans = Get(item.pId);
            if (plans == null)
                return null;
            plans.Duration = item.Duration;
            plans.Amount = item.Amount;
            _context.SaveChanges();
            return plans;
        }
        public Plan Delete(int key)
        {
            throw new NotImplementedException();
        }

        public  ICollection<Plan> GetAll()
        {
            if (_context != null)
            {
                return  _context.plans.ToList();
            }
              return null;
        }

        public ICollection<Plan> GetAllPlansByMember()
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePlans(int pId, Plan plan)
        {
            var _plan=await _context.plans.FindAsync(pId);
            if(_plan != null)
            {
                _plan.Duration = plan.Duration;
                _plan.Amount = plan.Amount;
                await _context.SaveChangesAsync();
            }
        }
       
    }
}
