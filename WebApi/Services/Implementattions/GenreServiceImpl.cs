using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;

namespace WebApi.Services.Implementattions
{
    public class GenreServiceImpl : IGenreService
    {

        private MySQLContext _context;

        public GenreServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Genre Create(Genre genre)
        {
            try
            {
                _context.Add(genre);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return genre;
        }

        // Método responsável por retornar uma pessoa
        public Genre FindById(long id)
        {
            return _context.Genres.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Genre> FindAll()
        {
            return _context.Genres.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Genre Update(Genre genre)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(genre.Id)) return new Genre();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Genres.SingleOrDefault(b => b.Id == genre.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(genre);
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
            var result = _context.Genres.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Genres.Remove(result);
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
            return _context.Genres.Any(p => p.Id.Equals(id));
        }
    }
}
