using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeAbilityBusiness
    {
        HeroeAbility Create(HeroeAbility item);
        List<HeroeAbility> FindByIdA(long id);
        List<HeroeAbility> FindByIdB(long id);

        List<Heroe> FindObjectA(long idObjectB);
        List<Ability> FindObjectB(long idObjectA);

        List<HeroeAbility> FindAll();
    }
}
