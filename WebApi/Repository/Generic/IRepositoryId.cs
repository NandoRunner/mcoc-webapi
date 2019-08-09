using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;

namespace WebApi.Repository.Generic
{
    public interface IRepositoryId<T> where T : BaseIdEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();

        T Update(T item);
        void Delete(long id);
    }
}
