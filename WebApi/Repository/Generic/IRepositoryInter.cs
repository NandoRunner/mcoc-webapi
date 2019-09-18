using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Model.Base;

namespace WebApi.Repository.Generic
{
    public interface IRepositoryInter<T, A, B> where T : BaseInterEntity
        where A : BaseEntity
        where B : BaseEntity
    {
        T Create(T item);
        List<T> FindByIdA(long id_a);
        List<T> FindByIdB(long id_b);

        List<T> FindAll();

        List<A> FindObjectA(long id_b);
        List<B> FindObjectB(long id_a);
            
        T Update(T item);
    }
}
