using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IHeroeHashtagBusiness
    {
        HeroeHashtag Create(HeroeHashtag item);
        List<HeroeHashtag> FindByIdA(long id);
        List<HeroeHashtag> FindByIdB(long id);

        List<Heroe> FindObjectA(long idObjectB);
        List<Hashtag> FindObjectB(long idObjectA);

        List<HeroeHashtag> FindAll();
    }
}
