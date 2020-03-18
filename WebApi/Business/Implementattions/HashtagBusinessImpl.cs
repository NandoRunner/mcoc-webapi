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
    public class HashtagBusinessImpl : IHashtagBusiness
    {
        private readonly IRepository<Hashtag> _repository;

        private readonly HashtagConverter _converter;


        public HashtagBusinessImpl(IRepository<Hashtag> repository
            //, IViewRepository<_vw_mc_ator> vrep
            )
        {
            _repository = repository;
            _converter = new HashtagConverter();
            //_vrep = vrep;
        }

        public HashtagVO Create(HashtagVO mccHashtag)
        {
            //return _repository.Create(mccHashtag);

            var ent = _converter.Parse(mccHashtag);
            ent = _repository.Create(ent);
            return _converter.Parse(ent);
        }

        public HashtagVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<HashtagVO> FindByName(string name)
        {
            return _converter.ParseList(_repository.FindByName(name));
        }

        public HashtagVO FindByExactName(string name)
        {
            return _converter.Parse(_repository.FindByExactName(name));
        }

        public List<HashtagVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public HashtagVO Update(HashtagVO mccHashtag)
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

        public HashtagVO FindOrCreate(HashtagVO item)
        {
            var ent = _converter.Parse(item);
            try
            {
                ent = _repository.FindOrCreate(ent);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return _converter.Parse(ent);
        }


    }
}
