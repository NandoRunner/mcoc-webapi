using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Model.Base;

namespace WebApi.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T FindOrCreate(T item);
        T Create(T item);
        Ability CreateAbility(Ability item);
        T FindById(long id);
        List<Ability> FindByName(string name, enAbility type);
        List<T> FindByName(string name);
        T FindByExactName(string name);

        Ability FindByExactName(string name, enAbility type);

        List<T> FindAll();

        List<Heroe> FindByNameHeroe(string name, enHeroeClass heroeClass);
        List<Heroe> FindAllHeroe(enHeroeClass heroeClass);
        List<Ability> FindAllAbility(enAbility type);

        T Update(T item);
        void Delete(long id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
