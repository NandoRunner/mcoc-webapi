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
    public class HeroeBusinessImpl : IHeroeBusiness
    {
        private readonly IRepository<Heroe> _repository;

        private readonly HeroeConverter _converter;


        public HeroeBusinessImpl(IRepository<Heroe> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new HeroeConverter();
            //_vrep = vrep;
        }

        public HeroeVO Create(HeroeVO mccHeroe)
        {
            //return _repository.Create(mccHeroe);

            var ent = _converter.Parse(mccHeroe);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public HeroeVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<HeroeVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public HeroeVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<HeroeVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public HeroeVO Update(HeroeVO mccHeroe)
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

        public HeroeVO FindOrCreate(HeroeVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.FindOrCreate(ent);
            return _converter.Parse(ent);
        }
    }
}
