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
    public class MccHashtagBusinessImpl : IMccHashtagBusiness
    {
        private readonly IRepository<MccHashtag> _repository;

        private readonly MccHashtagConverter _converter;


        public MccHashtagBusinessImpl(IRepository<MccHashtag> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new MccHashtagConverter();
            //_vrep = vrep;
        }

        public MccHashtagVO Create(MccHashtagVO mccHashtag)
        {
            //return _repository.Create(mccHashtag);

            var ent = _converter.Parse(mccHashtag);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public MccHashtagVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<MccHashtagVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public MccHashtagVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<MccHashtagVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public MccHashtagVO Update(MccHashtagVO mccHashtag)
        {
            //return  _repository.Update(mccHashtag);
            var ent = _converter.Parse(mccHashtag);
            ent = _repository.Update(ent);
            return _converter.Parse(ent);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public MccHashtagVO FindOrCreate(MccHashtagVO item)
        {
            var ent = _converter.Parse(item);
            ent = _repository.FindOrCreate(ent);
            return _converter.Parse(ent);
        }

        //public List<_vw_mc_ator> FindMovieCount(enMovieCount order)
        //{
        //    return _vrep.FindMovieCount(order);
        //}
    }
}
