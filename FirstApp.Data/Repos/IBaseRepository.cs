using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Data.Repos
{
    public interface IBaseRepository<T> where T: class
    {
        T Get(object id);
        Task<T> GetAsync(object id);
        IQueryable<T> GetAll();
        void Insert(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
        int Save();
        Task<int> SaveAsync();
    }
}
