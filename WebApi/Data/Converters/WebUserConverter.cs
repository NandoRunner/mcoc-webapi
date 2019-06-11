using System.Collections.Generic;
using WebApi.Data.Converter;
using WebApi.Model;
using System.Linq;

namespace WebApi.Data.Converters
{
    public class WebUserConverter : IParser<WebUserVO, WebUser>, IParser<WebUser, WebUserVO>
    {
        public WebUser Parse(WebUserVO origin)
        {
            if (origin == null) return new WebUser();
            return new WebUser
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public WebUserVO Parse(WebUser origin)
        {
            if (origin == null) return new WebUserVO();
            return new WebUserVO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<WebUser> ParseList(List<WebUserVO> origin)
        {
            if (origin == null) return new List<WebUser>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<WebUserVO> ParseList(List<WebUser> origin)
        {
            if (origin == null) return new List<WebUserVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
