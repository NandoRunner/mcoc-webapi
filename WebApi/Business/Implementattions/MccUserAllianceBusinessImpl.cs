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
    public class MccUserAllianceBusinessImpl : IMccUserAllianceBusiness
    {
        private readonly IRepositoryInter<MccUserAlliance> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public MccUserAllianceBusinessImpl(IRepositoryInter<MccUserAlliance> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public MccUserAlliance Create(MccUserAlliance mccUserAlliance)
        {
            return _repository.Create(mccUserAlliance);
        }

        public MccUserAlliance FindByIdA(long id)
        {
            return _repository.FindByIdA(id);
        }

        public MccUserAlliance FindByIdB(long id)
        {
            return _repository.FindByIdB(id);
        }

        //public List<MccUserAlliance> FindByName(string name)
        //{
        //    return _repository.FindByName(name);
        //}

        public List<MccUserAlliance> FindAll()
        {
            return _repository.FindAll();
        }

        public MccUserAlliance Update(MccUserAlliance mccUserAlliance)
        {
            return  _repository.Update(mccUserAlliance);
        }

        //public void Delete(long id)
        //{
        //    _repository.Delete(id);
        //}

        //public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        //{
        //    return _vrep.FindMovieCount(order);
        //}
    }
}
