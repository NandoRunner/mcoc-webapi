using System.Collections.Generic;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IAbilityBusiness
    {
        AbilityVO FindOrCreate(AbilityVO item);
        AbilityVO Create(AbilityVO item);
        AbilityVO FindById(long id);
        List<AbilityVO> FindByName(string name, enAbility type);
        AbilityVO FindByExactName(string name, enAbility type);
        List<AbilityVO> FindAll(enAbility type);

        AbilityVO Update(AbilityVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
