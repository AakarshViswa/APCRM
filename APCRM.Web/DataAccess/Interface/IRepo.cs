using System.Linq.Expressions;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();      
        void AddAsync(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities); 
              
    }
}
