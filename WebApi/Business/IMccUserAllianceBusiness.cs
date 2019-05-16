using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IMccUserAllianceBusiness
    {
        MccUserAlliance Create(MccUserAlliance item);
        MccUserAlliance FindByIdA(long id);
        MccUserAlliance FindByIdB(long id);

        List<MccUserAlliance> FindAll();
    }
}
