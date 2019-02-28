using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;

namespace WebApi.Services.Implementattions
{
    public class ActorServiceImpl : IActorService
    {

        private MySQLContext _context;

        public ActorServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Actor Create(Actor person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        // Método responsável por retornar uma pessoa
        public Actor FindById(long id)
        {
            return _context.Actors.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Actor> FindAll()
        {
            return _context.Actors.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Actor Update(Actor person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(person.Id)) return new Actor();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Actors.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
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
            var result = _context.Actors.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Actors.Remove(result);
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
            return _context.Actors.Any(p => p.Id.Equals(id));
        }
    }
}
