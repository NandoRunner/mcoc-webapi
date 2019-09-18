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
            var ret = FindById(item.id_a, item.id_b);
            if (ret != null)
                return ret;
            return Create(item);
        }

        public T Create(T item)
        {
            if (Exists(item.id_a, item.id_b)) return null;

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
            return dataset.OrderBy(p => p.id_a).OrderBy(p => p.id_b).ToList();
        }

        public List<T> FindByIdA(long id)
        {
            return dataset.Where(p => p.id_a.Equals(id)).OrderBy(p => p.id_b).ToList(); 
        }

        public List<T> FindByIdB(long id)
        {
            return dataset.Where(p => p.id_b.Equals(id)).OrderBy(p => p.id_a).ToList(); 
        }

        public T FindById(long id_a, long id_b)
        {
            return dataset.SingleOrDefault(p => p.id_a.Equals(id_a) && p.id_b.Equals(id_b));
        }

        public T Update(T item)
        {
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(item.id_a, item.id_b)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = dataset.SingleOrDefault(p => p.id_a == item.id_a && p.id_b == item.id_b);
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

        private bool Exists(long id_a, long id_b)
        {
            return dataset.Any(p => p.id_a.Equals(id_a) && p.id_b.Equals(id_b));
        }

        public List<A> FindObjectA(long id_b)
        {
            var list = (from x in dataset.AsEnumerable()
                        where x.id_b == id_b
                        select x.id_a).ToList();

            var ret = (from y in dsa.AsEnumerable()
                      where list.Contains((long)y.id)
                      select y).OrderBy(x => x.name).ToList(); 

            return ret;
        }

        public List<B> FindObjectB(long id_a)
        {
            var list = (from x in dataset.AsEnumerable()
                        where x.id_a == id_a
                        select x.id_b).ToList();

            var ret = (from y in dsb.AsEnumerable()
                       where list.Contains((long)y.id)
                       select y).OrderBy(x => x.name).ToList();

            return ret;
        }

    }
}
