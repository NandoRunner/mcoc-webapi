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

        public HeroeHashtagBusinessImpl(IRepositoryInter<HeroeHashtag, Heroe, Hashtag> repository
            )
        {
            _repository = repository;
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

        public List<Heroe> FindObjectA(long idObjectB)
        {
            return _repository.FindObjectA(idObjectB);
        }

        public List<Hashtag> FindObjectB(long idObjectA)
        {
            return _repository.FindObjectB(idObjectA);
        }

    }
}
