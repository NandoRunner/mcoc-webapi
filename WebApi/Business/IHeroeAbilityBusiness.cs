using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeAbilityBusiness
    {
        HeroeAbility Create(HeroeAbility item);
        List<HeroeAbility> FindByIdA(long id);
        List<HeroeAbility> FindByIdB(long id);

        List<Heroe> FindObjectA(long id_b);
        List<Ability> FindObjectB(long id_a);

        List<HeroeAbility> FindAll();
    }
}
