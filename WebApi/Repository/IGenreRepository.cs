using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IGenreRepository
    {
        Genre Create(Genre genre);
        Genre FindById(long id);
        List<Genre> FindByName(string name);
        List<Genre> FindAll();
    }
}
