using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Business
{
    public interface IMovieBusiness
    {
        Movie Create(Movie movie);
        Movie FindById(long id);
        List<Movie> FindByName(string name);
        List<Movie> FindAll();

        List<_vw_mc_filme_visto> FindWatched(enMovieCount order);
        List<_vw_mc_filme_ver> FindAvailable(enMovieCount order);
    }
}
