using CMSWebApi.Models;

namespace CMSWebApi.Services
{
    public interface IRepo<K,T>
    {
        T Add(T item);
        T Get(K key);
        ICollection<T> GetAll();
        ICollection<T> GetAllPlansByMember();

        T Update(T item);
        T Delete(K key);
        Task UpdatePlans(int pId,Plan plan);
    
    }
}
