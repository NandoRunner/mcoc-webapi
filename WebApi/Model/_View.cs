using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Base;

namespace WebApi.Model
{

    public class ViewResponse<T> where T : BaseView
    {
        public List<T> server_response { get; set; }
    }
}
