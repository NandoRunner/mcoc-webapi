using System.Collections.Generic;
using WebApi.Data.VO;

namespace WebApi.Business
{
    public interface IUserBusiness
    {
        UserVO Create(UserVO usr);
        UserVO FindById(long id);
        List<UserVO> FindByName(string name);
        List<UserVO> FindAll();

        UserVO Update(UserVO usr);
        void Delete(long id);
    }
}
