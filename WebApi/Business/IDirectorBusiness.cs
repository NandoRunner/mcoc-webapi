using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Business
{
    public interface IDirectorBusiness
    {
        Director Create(Director director);
        Director FindById(long id);
        List<Director> FindByName(string name);
        List<Director> FindAll();

        Director Update(Director director);
        void Delete(long id);

        List<_vw_mc_diretor> FindMovieCount(enMovieCount order);
    }
}
