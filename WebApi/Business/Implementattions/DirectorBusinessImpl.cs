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
    public class DirectorBusinessImpl : IDirectorBusiness
    {
        private readonly IRepository<Director> _repository;

        private readonly IViewRepository<_vw_mc_diretor> _vrep;


        public DirectorBusinessImpl(IRepository<Director> repository, IViewRepository<_vw_mc_diretor> vrep)
        {
            _repository = repository;
            _vrep = vrep;
        }

        public Director Create(Director director)
        {
			return _repository.Create(director);
        }

        public Director FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Director> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<Director> FindAll()
        {
            return _repository.FindAll();
        }

        public Director Update(Director director)
        {
            return  _repository.Update(director);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<_vw_mc_diretor> FindMovieCount(enMovieCount order)
        {
            return _vrep.FindMovieCount(order);
        }
    }
}
