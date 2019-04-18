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
    public class MccSynergyBusinessImpl : IMccSynergyBusiness
    {
        private readonly IRepository<MccSynergy> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public MccSynergyBusinessImpl(IRepository<MccSynergy> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public MccSynergy Create(MccSynergy mccSynergy)
        {
            return _repository.Create(mccSynergy);
        }

        public MccSynergy FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<MccSynergy> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<MccSynergy> FindAll()
        {
            return _repository.FindAll();
        }

        public MccSynergy Update(MccSynergy mccSynergy)
        {
            return  _repository.Update(mccSynergy);
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
