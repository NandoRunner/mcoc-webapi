using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;

namespace WebApi.Repository.Implementattions
{
    public class MovieBusinessImpl : IMovieBusiness
    {

        private MySQLContext _context;

        public MovieBusinessImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Movie Create(Movie movie)
        {
            try
            {
                _context.Add(movie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return movie;
        }

        // Método responsável por retornar uma pessoa
        public Movie FindById(long id)
        {
            return _context.Movies.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Movie> FindAll()
        {
            return _context.Movies.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Movie Update(Movie movie)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(movie.Id)) return new Movie();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Movies.SingleOrDefault(b => b.Id == movie.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(movie);
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
            var result = _context.Movies.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Movies.Remove(result);
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
            return _context.Movies.Any(p => p.Id.Equals(id));
        }
    }
}
