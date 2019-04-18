using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccSynergyBusiness
    {
        MccSynergy Create(MccSynergy item);
        MccSynergy FindById(long id);
        List<MccSynergy> FindByName(string name);
        List<MccSynergy> FindAll();

        MccSynergy Update(MccSynergy item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
