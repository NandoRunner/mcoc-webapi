using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Services
{
    public interface IGenreService
    {
        Genre Create(Genre genre);
        Genre FindById(long id);
        List<Genre> FindAll();
        //Actor Update(Actor actor);
        //void Delete(long id);
    }
}
