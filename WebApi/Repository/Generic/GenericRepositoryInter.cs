using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Model.Base;
using WebApi.Model.Context;

namespace WebApi.Repository.Generic
{
    public class GenericRepositoryInter<T, A, B> : IRepositoryInter<T, A, B> where T : BaseInterEntity
        where A : BaseEntity
        where B : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataset;
        private DbSet<A> dsa;
        private DbSet<B> dsb;


        public GenericRepositoryInter(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
            dsa = _context.Set<A>();
            dsb = _context.Set<B>();
        }

        public T FindOrCreate(T item)
        {
            var ret = FindById(item.idObjectA, item.idObjectB);
            if (ret != null)
                return ret;
            return Create(item);
        }

        public T Create(T item)
        {
            if (Exists(item.idObjectA, item.idObjectB)) return null;

            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

    
        public List<T> FindAll()
        {
            return dataset.OrderBy(p => p.idObjectA).OrderBy(p => p.idObjectB).ToList();
        }

        public List<T> FindByIdA(long id)
        {
            return dataset.Where(p => p.idObjectA.Equals(id)).OrderBy(p => p.idObjectB).ToList(); 
        }

        public List<T> FindByIdB(long id)
        {
            return dataset.Where(p => p.idObjectB.Equals(id)).OrderBy(p => p.idObjectA).ToList(); 
        }

        public T FindById(long idObjectA, long idObjectB)
        {
            return dataset.SingleOrDefault(p => p.idObjectA.Equals(idObjectA) && p.idObjectB.Equals(idObjectB));
        }

        public T Update(T item)
        {
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(item.idObjectA, item.idObjectB)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = dataset.SingleOrDefault(p => p.idObjectA == item.idObjectA && p.idObjectB == item.idObjectB);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        private bool Exists(long idObjectA, long idObjectB)
        {
            return dataset.Any(p => p.idObjectA.Equals(idObjectA) && p.idObjectB.Equals(idObjectB));
        }

        public List<A> FindObjectA(long idObjectB)
        {
            var list = (from x in dataset.AsEnumerable()
                        where x.idObjectB == idObjectB
                        select x.idObjectA).ToList();

            var ret = (from y in dsa.AsEnumerable()
                      where list.Contains((long)y.id)
                      select y).OrderBy(x => x.name).ToList(); 

            return ret;
        }

        public List<B> FindObjectB(long idObjectA)
        {
            var list = (from x in dataset.AsEnumerable()
                        where x.idObjectA == idObjectA
                        select x.idObjectB).ToList();

            var ret = (from y in dsb.AsEnumerable()
                       where list.Contains((long)y.id)
                       select y).OrderBy(x => x.name).ToList();

            return ret;
        }

    }
}
