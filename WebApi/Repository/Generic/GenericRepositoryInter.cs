using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;
using WebApi.Model.Context;

namespace WebApi.Repository.Generic
{
    public class GenericRepositoryInter<T> : IRepositoryInter<T> where T : BaseInterEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataset; 


        public GenericRepositoryInter(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
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

        public T FindByIdA(long id)
        {
            return dataset.SingleOrDefault(p => p.id_a.Equals(id));
        }

        public T FindByIdB(long id)
        {
            return dataset.SingleOrDefault(p => p.id_b.Equals(id));
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
    }
}
