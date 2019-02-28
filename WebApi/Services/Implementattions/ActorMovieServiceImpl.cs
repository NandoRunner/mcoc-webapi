using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;

namespace WebApi.Services.Implementattions
{
    public class ActorMovieServiceImpl : IActorMovieService
    {
        private MySQLContext _context;

        public ActorMovieServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public ActorMovie Create(ActorMovie actormovie)
        {
            try
            {
                _context.Add(actormovie);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actormovie;
        }

        // Método responsável por retornar uma pessoa
        public ActorMovie FindByActorId(long id)
        {
            return _context.ActorMovies.SingleOrDefault(p => p.ActorId.Equals(id));
        }
        

        // Método responsável por retornar todas as pessoas
        public List<ActorMovie> FindAll()
        {
            return _context.ActorMovies.ToList();
        }

        public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        {
            if (order == enMovieCount.name)
            {
                return _context.vw_mc_ator.OrderBy(p => p.Ator).ToList();
            }
            else
            {
                return _context.vw_mc_ator.ToList();
            }
        }

        public ActorMovie FindByMovieId(long id)
        {
            return _context.ActorMovies.SingleOrDefault(p => p.MovieId.Equals(id));
        }

    }
}
