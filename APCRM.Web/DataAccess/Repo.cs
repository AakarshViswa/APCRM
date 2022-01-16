using APCRM.Web.DataAccess.Interface;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using APCRM.Web.Data;

namespace APCRM.Web.DataAccess
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repo(ApplicationDbContext db)
        {
            _db = db;
            DbSet = _db.Set<T>();
        }

        public void AddAsync(T entity)
        {
           DbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = DbSet;
            return await query.ToListAsync();  
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
           DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           DbSet.RemoveRange(entities);
        }
    }
}
