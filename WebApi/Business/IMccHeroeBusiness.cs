using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccHeroeBusiness
    {
        MccHeroe Create(MccHeroe item);
        MccHeroe FindById(long id);
        List<MccHeroe> FindByName(string name);
        List<MccHeroe> FindAll();

        MccHeroe Update(MccHeroe item);
        void Delete(long id);

        //List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
