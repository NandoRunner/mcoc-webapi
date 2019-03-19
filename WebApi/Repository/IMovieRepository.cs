using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IMovieBusiness
    {
        Movie Create(Movie movie);
        Movie FindById(long id);
        List<Movie> FindAll();
        //Actor Update(Actor actor);
        //void Delete(long id);
    }
}
