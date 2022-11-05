using CMSWebApi.Models;

namespace CMSWebApi.Services
{
    public class MemberRepo : IRepo<int, Member>
    {
        static List<Member> _members = new List<Member>() { };
        public Member Add(Member item)
        {
            _members.Add(item);
            return (item);
        }

        public Member Get(int key)
        {
            var employee = _members.FirstOrDefault(x => x.Id == key);
            return employee;
        }

        public ICollection<Member> GetAll()
        {
            return _members;
        }

        public Member Update(Member item)
        {
            throw new NotImplementedException();
        }
        public Member Delete(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Member> GetAllPlansByMember()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlans(int pId, Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
