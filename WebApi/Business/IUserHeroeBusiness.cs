using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IUserHeroeBusiness
    {
        UserHeroe Create(UserHeroe item);
        UserHeroe FindByIdA(long id);
        UserHeroe FindByIdB(long id);

        List<UserHeroe> FindAll();
    }
}
