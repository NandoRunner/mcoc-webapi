﻿using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;

namespace WebApi.Business.Implementattions
{
    public class DirectorBusinessImpl : IDirectorBusiness
    {

        private IDirectorRepository _repository;

        public DirectorBusinessImpl(IDirectorRepository repository)
        {
            _repository = repository;
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

    }
}
