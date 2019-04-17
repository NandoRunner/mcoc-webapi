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
    public class MccHeroeBusinessImpl : IMccHeroeBusiness
    {
        private readonly IRepository<MccHeroe> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public MccHeroeBusinessImpl(IRepository<MccHeroe> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public MccHeroe Create(MccHeroe mccHeroe)
        {
            return _repository.Create(mccHeroe);
        }

        public MccHeroe FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<MccHeroe> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<MccHeroe> FindAll()
        {
            return _repository.FindAll();
        }

        public MccHeroe Update(MccHeroe mccHeroe)
        {
            return  _repository.Update(mccHeroe);
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
