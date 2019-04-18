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
    public class MccHeroeBusinessImpl : IMccHeroeBusiness
    {
        private readonly IRepository<MccHeroe> _repository;

        private readonly MccHeroeConverter _converter;


        public MccHeroeBusinessImpl(IRepository<MccHeroe> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new MccHeroeConverter();
            //_vrep = vrep;
        }

        public MccHeroeVO Create(MccHeroeVO mccHeroe)
        {
            //return _repository.Create(mccHeroe);

            var ent = _converter.Parse(mccHeroe);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public MccHeroeVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<MccHeroeVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public MccHeroeVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<MccHeroeVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public MccHeroeVO Update(MccHeroeVO mccHeroe)
        {
            //return  _repository.Update(mccHeroe);
            var ent = _converter.Parse(mccHeroe);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        //public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        //{
        //    return _vrep.FindMovieCount(order);
        //}
    }
}
