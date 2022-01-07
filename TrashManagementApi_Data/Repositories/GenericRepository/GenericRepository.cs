using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrashManagementApi_Data.Context;

namespace TrashManagementApi_Data.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected TrashManagementDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(TrashManagementDbContext context)
        {
            this.context = context;

            dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public bool Delete(long id)
        {
            var model =  dbSet.Find(id);
            dbSet.Remove(model);

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(long id)
        {
            var model = await dbSet.FindAsync(id);
            return model;
        }

        public bool Update(T entity)
        {
            if (entity != null)
            {
                dbSet.Update(entity);
                return true;
            }
            return false;
        }
    }
}
