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
    public class HeroeHashtagBusinessImpl : IHeroeHashtagBusiness
    {
        private readonly IRepositoryInter<HeroeHashtag> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public HeroeHashtagBusinessImpl(IRepositoryInter<HeroeHashtag> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public HeroeHashtag Create(HeroeHashtag mccHeroeHashtag)
        {
            return _repository.Create(mccHeroeHashtag);
        }

        public HeroeHashtag FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public HeroeHashtag FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        public List<HeroeHashtag> FindAll()
        {
            return _repository.FindAll();
        }

    }
}
