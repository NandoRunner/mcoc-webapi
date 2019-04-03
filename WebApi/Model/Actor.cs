using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("mc_ato_ator")]
    public class Actor : BaseEntity { }
    
    public class ActorResponse
    {
        public List<_vw_mc_ator> server_response { get; set; }
    }

    public class _vw_mc_ator : BaseView { }
}
