using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashManagementApi_Data.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        bool Update(T entity);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        bool Delete(long id);

    }
}
