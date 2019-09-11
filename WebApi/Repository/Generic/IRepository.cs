using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;

namespace WebApi.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T FindOrCreate(T item);
        T Create(T item);
        T FindById(long id);
        List<T> FindByName(string name);
        T FindByExactName(string name);
        List<T> FindAll();

        T Update(T item);
        void Delete(long id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
