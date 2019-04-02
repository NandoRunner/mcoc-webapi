using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("mc_ato_ator")]
    public class Actor : BaseEntity
    {
        //[Key]
        //[Column("ato_ator_id")]
        public override long Id { get; set; }
        //[Column("ato_nome")]
        public override string Name { get; set; }
    }
}
