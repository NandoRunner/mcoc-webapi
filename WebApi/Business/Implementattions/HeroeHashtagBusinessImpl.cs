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
        private readonly IRepositoryInter<HeroeHashtag, Heroe, Hashtag> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public HeroeHashtagBusinessImpl(IRepositoryInter<HeroeHashtag, Heroe, Hashtag> repository
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

        public List<HeroeHashtag> FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public List<HeroeHashtag> FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        public List<HeroeHashtag> FindAll()
        {
            return _repository.FindAll();
        }

        public List<Heroe> FindObjectA(long id_b)
        {
            return _repository.FindObjectA(id_b);
        }

        public List<Hashtag> FindObjectB(long id_a)
        {
            return _repository.FindObjectB(id_a);
        }

    }
}
