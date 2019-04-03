using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;
using WebApi.Repository.Generic;
using WebApi.Data.Converters;
using WebApi.Data.VO;

namespace WebApi.Business.Implementattions
{
    public class GenreBusinessImpl : IGenreBusiness
    {
        private readonly IRepository<Genre> _repository;

        private readonly GenreConverter _converter;

        private readonly IViewRepository<_vw_mc_genero> _vrep;

        public GenreBusinessImpl(IRepository<Genre> repository, IViewRepository<_vw_mc_genero> vrep)
        {
            _repository = repository;
            _converter = new GenreConverter();
            _vrep = vrep;
        }

        public GenreVO Create(GenreVO genre)
        {
            var ent = _converter.Parse(genre);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public GenreVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<GenreVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public List<GenreVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public GenreVO Update(GenreVO genre)
        {
            var ent = _converter.Parse(genre);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);

        }

        public List<_vw_mc_genero> FindMovieCount(enMovieCount order)
        {
            return _vrep.FindMovieCount(order);
        }
    }
}
