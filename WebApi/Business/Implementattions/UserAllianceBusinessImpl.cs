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
    public class UserAllianceBusinessImpl : IUserAllianceBusiness
    {
        private readonly IRepositoryInter<UserAlliance> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public UserAllianceBusinessImpl(IRepositoryInter<UserAlliance> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public UserAlliance Create(UserAlliance mccUserAlliance)
        {
            return _repository.Create(mccUserAlliance);
        }

        public UserAlliance FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public UserAlliance FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        public List<UserAlliance> FindAll()
        {
            return _repository.FindAll();
        }

    }
}
