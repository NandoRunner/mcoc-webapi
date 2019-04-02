using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;
using WebApi.Repository.Generic;

namespace WebApi.Business.Implementattions
{
    public class GenreBusinessImpl : IGenreBusiness
    {
        private readonly IRepository<Genre> _repository;

        //private IGenreRepository _repository;

        public GenreBusinessImpl(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        public Genre Create(Genre genre)
        {
			return _repository.Create(genre);
        }

        public Genre FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Genre> FindByName(string name)
        {
            return _repository.FindByName(name);
        }
		
        public List<Genre> FindAll()
        {
            return _repository.FindAll();
        }

     }
}
