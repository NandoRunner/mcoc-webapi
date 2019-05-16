using System.Collections.Generic;
using WebApi.Data.VO;


namespace WebApi.Business
{
    public interface IHashtagBusiness
    {
        HashtagVO FindOrCreate(HashtagVO item);
        HashtagVO Create(HashtagVO item);
        HashtagVO FindById(long id);
        List<HashtagVO> FindByName(string name);
        HashtagVO FindByExactName(string name);
        List<HashtagVO> FindAll();

        HashtagVO Update(HashtagVO item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
