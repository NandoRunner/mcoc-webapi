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
    public class UserHeroeBusinessImpl : IUserHeroeBusiness
    {
        private readonly IRepositoryInter<UserHeroe> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public UserHeroeBusinessImpl(IRepositoryInter<UserHeroe> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public UserHeroe Create(UserHeroe mccUserHeroe)
        {
            return _repository.Create(mccUserHeroe);
        }

        public UserHeroe FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public UserHeroe FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        public List<UserHeroe> FindAll()
        {
            return _repository.FindAll();
        }

    }
}
