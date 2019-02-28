using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Services
{
    public interface IActorService
    {
        Actor Create(Actor person);
        Actor FindById(long id);
        List<Actor> FindAll();
        //Actor Update(Actor person);
        //void Delete(long id);
    }
}
