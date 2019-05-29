using System.Collections.Generic;
using WebApi.Data.VO;

namespace WebApi.Business
{
    public interface IAllianceBusiness
    {
        AllianceVO Create(AllianceVO aly);
        AllianceVO FindById(long id);
        List<AllianceVO> FindByName(string name);
        List<AllianceVO> FindAll();

        AllianceVO Update(AllianceVO aly);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
