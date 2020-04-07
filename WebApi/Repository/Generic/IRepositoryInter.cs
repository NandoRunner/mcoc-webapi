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
        List<T> FindByIdA(long idObjectA);
        List<T> FindByIdB(long idObjectB);

        List<T> FindAll();

        List<A> FindObjectA(long idObjectB);
        List<B> FindObjectB(long idObjectA);
            
        T Update(T item);
    }
}
