﻿using System.Collections.Generic;
using WebApi.Data.VO;

namespace WebApi.Business
{
    public interface IHeroeBusiness
    {
        HeroeVO FindOrCreate(HeroeVO item);
        HeroeVO Create(HeroeVO item);
        HeroeVO FindById(long id);
        List<HeroeVO> FindByName(string name);
        HeroeVO FindByExactName(string name);
        List<HeroeVO> FindAll();

        HeroeVO Update(HeroeVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
