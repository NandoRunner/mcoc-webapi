using System.Collections.Generic;
using WebApi.Data.VO;


namespace WebApi.Business
{
    public interface IMccAbilityBusiness
    {
        MccAbilityVO FindOrCreate(MccAbilityVO item);
        MccAbilityVO Create(MccAbilityVO item);
        MccAbilityVO FindById(long id);
        List<MccAbilityVO> FindByName(string name);
        MccAbilityVO FindByExactName(string name);
        List<MccAbilityVO> FindAll();

        MccAbilityVO Update(MccAbilityVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
