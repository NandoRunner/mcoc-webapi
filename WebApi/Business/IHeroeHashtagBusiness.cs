using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeHashtagBusiness
    {
        HeroeHashtag Create(HeroeHashtag item);
        HeroeHashtag FindByIdA(long id);
        HeroeHashtag FindByIdB(long id);

        List<HeroeHashtag> FindAll();
    }
}
