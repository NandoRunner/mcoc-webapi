using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeAbilityBusiness
    {
        HeroeAbility Create(HeroeAbility item);
        HeroeAbility FindByIdA(long id);
        HeroeAbility FindByIdB(long id);

        List<HeroeAbility> FindAll();
    }
}
