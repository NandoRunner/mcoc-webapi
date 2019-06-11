using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Business
{
    public interface IWebUserRepository
    {
        WebUser FindByLogin(string login);
    }
}
