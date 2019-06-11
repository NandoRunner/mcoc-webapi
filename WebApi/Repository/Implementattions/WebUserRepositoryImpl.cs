using WebApi.Model;
using WebApi.Model.Context;
using System.Linq;

namespace WebApi.Business.Implementattions
{
    public class WebUserRepositoryImpl : IWebUserRepository
    {
        private readonly MySQLContext _context;

        public WebUserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public WebUser FindByLogin(string login)
        {
            return _context.WebUsers.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
