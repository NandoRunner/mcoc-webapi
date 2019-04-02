using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("mc_ato_ator")]
    public class Actor
    {
        [Key]
        [Column("ato_ator_id")]
        public long? Id { get; set; }
        [Column("ato_nome")]
        public string Name { get; set; }
    }
}
