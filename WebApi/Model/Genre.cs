using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("mc_gen_genero")]
    public class Genre : BaseEntity { }

    public class _vw_mc_genero : BaseView { }
}
