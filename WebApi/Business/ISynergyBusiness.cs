using System.Collections.Generic;
using WebApi.Data.VO;

namespace WebApi.Business
{
    public interface ISynergyBusiness
    {
        SynergyVO FindOrCreate(SynergyVO item);
        SynergyVO Create(SynergyVO item);
        SynergyVO FindById(long id);
        List<SynergyVO> FindByName(string name);
        SynergyVO FindByExactName(string name);
        List<SynergyVO> FindAll();

        SynergyVO Update(SynergyVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
