using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IGenreRepository
    {
        Genre Create(Genre genre);
        Genre FindById(long id);
        List<Genre> FindAll();
        //Actor Update(Actor actor);
        //void Delete(long id);
    }
}
