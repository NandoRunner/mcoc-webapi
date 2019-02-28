using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;

namespace WebApi.Services.Implementattions
{
    public class DirectorServiceImpl : IDirectorService
    {

        private MySQLContext _context;

        public DirectorServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Director Create(Director director)
        {
            try
            {
                _context.Add(director);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return director;
        }

        // Método responsável por retornar uma pessoa
        public Director FindById(long id)
        {
            return _context.Directors.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Director> FindAll()
        {
            return _context.Directors.OrderBy(a => a.Name).ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Director Update(Director director)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(director.Id)) return new Director();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Directors.SingleOrDefault(b => b.Id == director.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(director);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            var result = _context.Directors.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Directors.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Exists(long? id)
        {
            return _context.Directors.Any(p => p.Id.Equals(id));
        }
    }
}
