using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;
using WebApi.Repository.Generic;
using WebApi.Data.Converters;
using WebApi.Data.VO;

namespace WebApi.Business.Implementattions
{
    public class UserBusinessImpl : IUserBusiness
    {
        private readonly IRepository<User> _repository;

        private readonly UserConverter _converter;


        public UserBusinessImpl(IRepository<User> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new UserConverter();
            //_vrep = vrep;
        }

        public UserVO Create(UserVO item)
        {
           var ent = _converter.Parse(item);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
         }

        public UserVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<UserVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public List<UserVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public UserVO Update(UserVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }


    }
}
