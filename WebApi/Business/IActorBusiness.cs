using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Business
{
    public interface IActorBusiness
    {
        Actor Create(Actor actor);
        Actor FindById(long id);
        List<Actor> FindByName(string name);
        List<Actor> FindAll();

        Actor Update(Actor actor);
        void Delete(long id);

        List<_vw_mc_ator> FindMovieCount(enMovieCount order);
    }
}
