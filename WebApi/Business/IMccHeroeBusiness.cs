using System.Collections.Generic;
using WebApi.Data.VO;


namespace WebApi.Business
{
    public interface IMccHeroeBusiness
    {
        MccHeroeVO Create(MccHeroeVO item);
        MccHeroeVO FindById(long id);
        List<MccHeroeVO> FindByName(string name);
        MccHeroeVO FindByExactName(string name);
        List<MccHeroeVO> FindAll();

        MccHeroeVO Update(MccHeroeVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
