﻿using McocApi.Util;
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
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ILog _logger;

        private readonly MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context, ILog logger)
        {
            _context = context;
            dataset = _context.Set<T>();
            _logger = logger;
        }

        public T FindOrCreate(T item)
        {
            var ret = FindByExactName(item.name);

            if (ret != null)
                return ret;
            try
            {
                return Create(item);
            }
            catch (Exception ex)
            {
                //_logger.Error("FindOrCreate");
                throw ex;
            }

        }

        public T Create(T item)
        {
            if (Exists(item.name)) return null;

            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Ability CreateAbility(Ability item)
        {
            if (Exists(item.name, item.type)) return null;

            DbSet<Ability> ds = _context.Set<Ability>();

            try
            {
                ds.Add(item);
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

        public List<Heroe> FindAllHeroe(enHeroeClass heroeClass)
        {

            DbSet<Heroe> dsHeroe = _context.Set<Heroe>();

            if (((enHeroeClass)heroeClass) == enHeroeClass.ALL)
            {
                return dsHeroe.OrderBy(a => a.name).ToList();
            }
            else
            {
                return dsHeroe.Where(a => a.heroeClass == (int)heroeClass).OrderBy(a => a.name).ToList();
            }
        }

        public List<Ability> FindAllAbility(enAbility type)
        {
            //todo: Pesquisar em case sensitive
            DbSet<Ability> dsAbility = _context.Set<Ability>();

            if (((enAbility)type) == enAbility.all)
            {
                return dsAbility.OrderBy(a => a.name).ToList();
            }
            else
            {
                return dsAbility.Where(a => a.type == (int)type).OrderBy(a => a.name).ToList();
            }
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.id.Equals(id));
        }

        public List<T> FindByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return dataset.Where(a => a.name.ToLower().Contains(name.ToLower())).OrderBy(a => a.name).ToList();
            }
            else
            {
                return dataset.OrderBy(a => a.name).ToList();
            }
        }

        public List<Ability> FindByName(string name, enAbility abilityType)
        {
            IQueryable<Ability> q;

            DbSet<Ability> ds = _context.Set<Ability>();

            if (!string.IsNullOrEmpty(name))
            {
                q = ds.Where(a => a.name.ToLower().Contains(name.ToLower())).OrderBy(a => a.name);
            }
            else
            {
                q = ds.OrderBy(a => a.name);
            }

            if (((enAbility)abilityType) != enAbility.all)
            {
                q = q.Where(a => a.type == (int)abilityType).OrderBy(a => a.name);
            }
            return q.ToList();
        }

        public List<Heroe> FindByNameHeroe(string name, enHeroeClass heroeClass)
        {
            DbSet<Heroe> dsHeroe = _context.Set<Heroe>();

            if (((enHeroeClass)heroeClass) == enHeroeClass.ALL)
            {
                return dsHeroe.Where(a => a.name.ToLower().Contains(name.ToLower())).OrderBy(a => a.name).ToList();
            }
            else
            {
                return dsHeroe.Where(a => a.heroeClass == (int)heroeClass).Where(a => a.name.ToLower().Contains(name.ToLower())).OrderBy(a => a.name).ToList();
            }
        }

        public T FindByExactName(string name)
        {
            return dataset.SingleOrDefault(p => p.name.Equals(name));
        }

        public Ability FindByExactName(string name, enAbility type)
        {
            DbSet<Ability> ds = _context.Set<Ability>();

            var ret = ds.SingleOrDefault(p => p.name.Equals(name) && (((enAbility)type) == enAbility.all || p.type == (int)type));

            return ret;
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            // https://stackoverflow.com/questions/40557003/entity-framework-core-count-does-not-have-optimal-performance
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }

            return Int32.Parse(result);
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

        private bool Exists(string name, int type = -1)
        {
            DbSet<Ability> ds = _context.Set<Ability>();

            return ds.Any(p => p.name.Equals(name) && (type == -1 || p.type == type));
        }
    }
}
