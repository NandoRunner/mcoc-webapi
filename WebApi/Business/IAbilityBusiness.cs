using System.Collections.Generic;
using WebApi.Data.VO;


namespace WebApi.Business
{
    public interface IAbilityBusiness
    {
        AbilityVO FindOrCreate(AbilityVO item);
        AbilityVO Create(AbilityVO item);
        AbilityVO FindById(long id);
        List<AbilityVO> FindByName(string name);
        AbilityVO FindByExactName(string name);
        List<AbilityVO> FindAll();

        AbilityVO Update(AbilityVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
