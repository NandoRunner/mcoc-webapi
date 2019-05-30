using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IUserAllianceBusiness
    {
        UserAlliance Create(UserAlliance item);
        UserAlliance FindByIdA(long id);
        UserAlliance FindByIdB(long id);

        List<UserAlliance> FindAll();
    }
}
