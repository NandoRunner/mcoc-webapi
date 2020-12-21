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

        private readonly IViewRepository<HeroePerAbility> _repview;

        private readonly AbilityConverter _converter;


        public AbilityBusinessImpl(IRepository<Ability> repository, IViewRepository<HeroePerAbility> repview
            )
        {
            _repository = repository;
            _repview = repview;
            _converter = new AbilityConverter();
        }

        public AbilityVO Create(AbilityVO item)
        {
            var ent = _converter.Parse(item);
            try
            {
                ent = _repository.CreateAbility(ent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _converter.Parse(ent);
        }

        public AbilityVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<AbilityVO> FindByName(string name, enAbility type = enAbility.all)
        {
            return _converter.ParseList(_repository.FindByName(name, type));
        }

        public AbilityVO FindByExactName(string name, enAbility type = enAbility.all)
        {
            return _converter.Parse(_repository.FindByExactName(name, type));
        }

        public List<AbilityVO> FindAll(enAbility type)
        {
            return _converter.ParseList(_repository.FindAllAbility(type));
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

        public List<HeroePerAbility> FindHeroeCountPerAbility(enAbility type)
        {
            return _repview.FindAll().Where(t => t.abilityType == (int)type || type == enAbility.all).ToList();
        }
    }
}
