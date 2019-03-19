using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IActorMovieRepository
    {
        ActorMovie Create(ActorMovie actormovie);
        ActorMovie FindByActorId(long id);
        ActorMovie FindByMovieId(long id);
        List<ActorMovie> FindAll();

        List<_vw_mc_ator> FindMovieCount(enMovieCount order);

    }
}
