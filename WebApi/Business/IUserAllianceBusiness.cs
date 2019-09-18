using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IUserAllianceBusiness
    {
        UserAlliance Create(UserAlliance item);
        List<UserAlliance> FindByIdA(long id);
        List<UserAlliance> FindByIdB(long id);

        List<UserAlliance> FindAll();
    }
}
