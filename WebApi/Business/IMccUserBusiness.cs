using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccUserBusiness
    {
        MccUser Create(MccUser usr);
        MccUser FindById(long id);
        List<MccUser> FindByName(string name);
        List<MccUser> FindAll();

        MccUser Update(MccUser usr);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
