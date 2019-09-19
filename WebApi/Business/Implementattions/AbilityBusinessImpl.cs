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
    public class AbilityBusinessImpl : IAbilityBusiness
    {
        private readonly IRepository<Ability> _repository;

        private readonly AbilityConverter _converter;


        public AbilityBusinessImpl(IRepository<Ability> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new AbilityConverter();
            //_vrep = vrep;
        }

        public AbilityVO Create(AbilityVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.CreateAbility(ent);
            return _converter.Parse(ent);
        }

        public AbilityVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<AbilityVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public AbilityVO FindByExactName(string name, int type = -1)
        {
            return _converter.Parse(_repository.FindByExactName(name, type));
        }

        public List<AbilityVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public AbilityVO Update(AbilityVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public AbilityVO FindOrCreate(AbilityVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.FindOrCreate(ent);
            return _converter.Parse(ent);
        }

    }
}
