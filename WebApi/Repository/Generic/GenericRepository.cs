using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;
using WebApi.Model.Context;

namespace WebApi.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataset; 


        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }


        public T Create(T item)
        {
            if (Exists(item.name)) return null;

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

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return dataset.OrderBy(a => a.name).ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.id.Equals(id));
        }

        public List<T> FindByName(string name)
        {
            return dataset.Where(a => a.name.Contains(name)).OrderBy(a => a.name).ToList();
        }

        public T FindByExactName(string name)
        {
            return dataset.SingleOrDefault(p => p.name.Equals(name));
        }

        public T Update(T item)
        {
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(item.id)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = dataset.SingleOrDefault(b => b.id == item.id);
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

        private bool Exists(long? id)
        {
            return dataset.Any(p => p.id.Equals(id));
        }

        private bool Exists(string name)
        {
            return dataset.Any(p => p.name.Equals(name));
        }
    }
}
