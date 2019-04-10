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
    public class MccUserBusinessImpl : IMccUserBusiness
    {
        private readonly IRepository<MccUser> _repository;

        //private readonly IViewRepository<_vw_mc_ator> _vrep;


        public MccUserBusinessImpl(IRepository<MccUser> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            //_vrep = vrep;
        }

        public MccUser Create(MccUser mccUser)
        {
            return _repository.Create(mccUser);
        }

        public MccUser FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<MccUser> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<MccUser> FindAll()
        {
            return _repository.FindAll();
        }

        public MccUser Update(MccUser mccUser)
        {
            return  _repository.Update(mccUser);
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
