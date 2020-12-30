using System.Collections.Generic;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IUserBusiness
    {
        User FindOrCreate(User item);

        User Create(User item);
        UserVO FindById(long id);
        List<UserVO> FindByName(string name);
        List<UserVO> FindAll();

        User Update(User item);
        void Delete(long id);
    }
}
