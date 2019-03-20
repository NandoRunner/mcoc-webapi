using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Repository
{
    public interface IDirectorRepository
    {
        Director Create(Director director);
        Director FindById(long id);
        List<Director> FindByName(string name);
        List<Director> FindAll();
    }
}
