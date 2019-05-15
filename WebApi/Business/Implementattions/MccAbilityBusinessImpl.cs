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
    public class MccAbilityBusinessImpl : IMccAbilityBusiness
    {
        private readonly IRepository<MccAbility> _repository;

        private readonly MccAbilityConverter _converter;


        public MccAbilityBusinessImpl(IRepository<MccAbility> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new MccAbilityConverter();
            //_vrep = vrep;
        }

        public MccAbilityVO Create(MccAbilityVO mccAbility)
        {
            //return _repository.Create(mccAbility);

            var ent = _converter.Parse(mccAbility);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public MccAbilityVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<MccAbilityVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public MccAbilityVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<MccAbilityVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public MccAbilityVO Update(MccAbilityVO mccAbility)
        {
            //return  _repository.Update(mccAbility);
            var ent = _converter.Parse(mccAbility);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public MccAbilityVO FindOrCreate(MccAbilityVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.FindOrCreate(ent);
            return _converter.Parse(ent);
        }

        //public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        //{
        //    return _vrep.FindMovieCount(order);
        //}
    }
}
