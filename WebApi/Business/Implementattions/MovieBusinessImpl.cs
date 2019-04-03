using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;

namespace WebApi.Business.Implementattions
{
    public class MovieBusinessImpl : IMovieBusiness
    {

        private IMovieRepository _repository;

        public MovieBusinessImpl(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Movie Create(Movie movie)
        {
            return _repository.Create(movie);
        }


        public Movie FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Movie> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<Movie> FindAll()
        {
			return _repository.FindAll();
        }

        public List<_vw_mc_filme_visto> FindWatched(enMovieCount order)
        {
            return _repository.FindWatched(order);
        }

        public List<_vw_mc_filme_ver> FindAvailable(enMovieCount order)
        {
            return _repository.FindAvailable(order);
        }


    }
}
