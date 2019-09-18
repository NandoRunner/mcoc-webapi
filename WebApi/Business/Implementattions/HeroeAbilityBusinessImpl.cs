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
    public class HeroeAbilityBusinessImpl : IHeroeAbilityBusiness
    {
        private readonly IRepositoryInter<HeroeAbility, Heroe, Ability> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public HeroeAbilityBusinessImpl(IRepositoryInter<HeroeAbility, Heroe, Ability> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public HeroeAbility Create(HeroeAbility mccHeroeAbility)
        {
            return _repository.Create(mccHeroeAbility);
        }

        public List<HeroeAbility> FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public List<HeroeAbility> FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        public List<HeroeAbility> FindAll()
        {
            return _repository.FindAll();
        }

    }
}
