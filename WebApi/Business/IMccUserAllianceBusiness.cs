using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccUserAllianceBusiness
    {
        MccUserAlliance Create(MccUserAlliance item);
        MccUserAlliance FindByIdA(long id);
        MccUserAlliance FindByIdB(long id);
        //List<MccUserAlliance> FindByName(string name);
        List<MccUserAlliance> FindAll();

        MccUserAlliance Update(MccUserAlliance item);
        //void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
