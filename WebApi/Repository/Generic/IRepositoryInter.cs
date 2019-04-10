using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;

namespace WebApi.Repository.Generic
{
    public interface IRepositoryInter<T> where T : BaseInterEntity
    {
        T Create(T item);
        T FindByIdA(long id_a);
        T FindByIdB(long id_b);
        List<T> FindAll();

        T Update(T item);
    }
}
