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
    public class SynergyBusinessImpl : ISynergyBusiness
    {
        private readonly IRepository<Synergy> _repository;

        private readonly SynergyConverter _converter;


        public SynergyBusinessImpl(IRepository<Synergy> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new SynergyConverter();
            //_vrep = vrep;
        }

        public SynergyVO Create(SynergyVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public SynergyVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<SynergyVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public SynergyVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<SynergyVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public SynergyVO Update(SynergyVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public SynergyVO FindOrCreate(SynergyVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.FindOrCreate(ent);
            return _converter.Parse(ent);
        }
    }
}
