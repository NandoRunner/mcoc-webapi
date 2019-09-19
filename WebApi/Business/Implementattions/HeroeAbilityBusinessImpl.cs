﻿using System.Collections.Generic;
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

        public HeroeAbilityBusinessImpl(IRepositoryInter<HeroeAbility, Heroe, Ability> repository
            )
        {
            _repository = repository;
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

        public List<Heroe> FindObjectA(long id_b)
        {
            return _repository.FindObjectA(id_b);
        }

        public List<Ability> FindObjectB(long id_a)
        {
            return _repository.FindObjectB(id_a);
        }

    }
}
