using WebApi.Model;

namespace WebApi.Business
{
    public interface ILoginBusiness
    {
         object FindByLogin(WebUserVO user);
    }
}
