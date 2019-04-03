using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("mc_dir_diretor")]
    public class Director : BaseEntity { }

    public class DirectorResponse
    {
        public List<_vw_mc_diretor> server_response { get; set; }
    }

    public class _vw_mc_diretor : BaseView { }
}
