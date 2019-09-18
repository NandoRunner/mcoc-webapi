using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IUserHeroeBusiness
    {
        UserHeroe Create(UserHeroe item);
        List<UserHeroe> FindByIdA(long id);
        List<UserHeroe> FindByIdB(long id);

        List<UserHeroe> FindAll();
    }
}
