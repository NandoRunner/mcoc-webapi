using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Business
{
    public interface IGenreBusiness
    {
        Genre Create(Genre genre);
        Genre FindById(long id);
        List<Genre> FindByName(string name);
        List<Genre> FindAll();
    }
}
