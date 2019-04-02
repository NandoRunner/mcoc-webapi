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
    public class ActorBusinessImpl : IActorBusiness
    {
        private readonly IRepository<Actor> _repository;

        //private IActorRepository _repository;

        public ActorBusinessImpl(IRepository<Actor> repository)
        {
            _repository = repository;
        }

        public Actor Create(Actor actor)
        {
            return _repository.Create(actor);
        }

        public Actor FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Actor> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public List<Actor> FindAll()
        {
            return _repository.FindAll();
        }

        public Actor Update(Actor actor)
        {
            return  _repository.Update(actor);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
