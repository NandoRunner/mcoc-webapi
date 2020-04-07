using System.Collections.Generic;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeBusiness
    {
        HeroeVO FindOrCreate(HeroeVO item);
        HeroeVO Create(HeroeVO item);
        HeroeVO FindById(long id);
        List<HeroeVO> FindByName(string name, enHeroeClass heroeClass);
        HeroeVO FindByExactName(string name);
        List<HeroeVO> FindAll(enHeroeClass heroeClass);

        HeroeVO Update(HeroeVO item);
        void Delete(long id);

        List<HeroePerClass> FindAll();

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
