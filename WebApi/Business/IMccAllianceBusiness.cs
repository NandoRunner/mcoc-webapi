using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccAllianceBusiness
    {
        MccAlliance Create(MccAlliance aly);
        MccAlliance FindById(long id);
        List<MccAlliance> FindByName(string name);
        List<MccAlliance> FindAll();

        MccAlliance Update(MccAlliance aly);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
