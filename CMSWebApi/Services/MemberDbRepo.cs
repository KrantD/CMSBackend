using CMSWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSWebApi.Services
{
    public class MemberDbRepo : IRepo<int, Member>
    {
        private readonly ClaimContext _context;

        public MemberDbRepo(ClaimContext context)
        {
            _context = context;
        }
        public Member Add(Member item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        public Member Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Member Get(int key)
        {
            var mem = _context.members.FirstOrDefault(e => e.Id == key);
            if (mem != null)
            {
                try
                {
                    return mem;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }
        public ICollection<Member> GetAll()
        {
            if (_context.members.Count() > 0)
                return _context.members.ToList();
            return null;
        }


        public ICollection<Member> GetAllPlansByMember()
        {
            var Member = _context.members.Include(e => e.MemberPlans).ThenInclude(y => y.Plan).ToList();
            return Member;
        }

        public Member Update(Member item)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlans(int pId, Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
