using CMSWebApi.Models;

namespace CMSWebApi.Services
{
    public class MemberPlanRepo : IRepo<int, MemberPlan>
    {
        private readonly ClaimContext _context;

        public MemberPlanRepo(ClaimContext context)
        {
            _context = context;
        }
        public MemberPlan Add(MemberPlan item)
        {
            throw new NotImplementedException();
        }

        public MemberPlan Delete(int key)
        {
            throw new NotImplementedException();
        }

        public MemberPlan Get(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<MemberPlan> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<MemberPlan> GetAllPlansByMember()
        {
            throw new NotImplementedException();
        }

        public MemberPlan Update(MemberPlan item)
        {
            //    var plans = Get(item.Id);
            //    if (plans == null)
            //        return null;
            //    plans.Duration = item.Duration;
            //    plans.Amount = item.Amount;
            //    _context.SaveChanges();
            //    return plans;
            throw new NotImplementedException();
        }

        public Task UpdatePlans(int pId, Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
