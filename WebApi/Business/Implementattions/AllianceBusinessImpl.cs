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
    public class AllianceBusinessImpl : IAllianceBusiness
    {
        private readonly IRepository<Alliance> _repository;

        private readonly AllianceConverter _converter;


        public AllianceBusinessImpl(IRepository<Alliance> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new AllianceConverter();
            //_vrep = vrep;
        }

        public AllianceVO Create(AllianceVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public AllianceVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<AllianceVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public List<AllianceVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public AllianceVO Update(AllianceVO item)
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
