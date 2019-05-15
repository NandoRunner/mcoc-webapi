using System.Collections.Generic;
using WebApi.Data.VO;


namespace WebApi.Business
{
    public interface IMccHashtagBusiness
    {
        MccHashtagVO FindOrCreate(MccHashtagVO item);
        MccHashtagVO Create(MccHashtagVO item);
        MccHashtagVO FindById(long id);
        List<MccHashtagVO> FindByName(string name);
        MccHashtagVO FindByExactName(string name);
        List<MccHashtagVO> FindAll();

        MccHashtagVO Update(MccHashtagVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
