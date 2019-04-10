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
    public class MccAllianceBusinessImpl : IMccAllianceBusiness
    {
        private readonly IRepository<MccAlliance> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public MccAllianceBusinessImpl(IRepository<MccAlliance> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public MccAlliance Create(MccAlliance mccAlliance)
        {
            return _repository.Create(mccAlliance);
        }

        public MccAlliance FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<MccAlliance> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<MccAlliance> FindAll()
        {
            return _repository.FindAll();
        }

        public MccAlliance Update(MccAlliance mccAlliance)
        {
            return  _repository.Update(mccAlliance);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        //public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        //{
        //    return _vrep.FindMovieCount(order);
        //}
    }
}
