using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("mc_gen_genero")]
    public class Genre
    {
        [Key]
        [Column("gen_genero_id")]
        public long? Id { get; set; }
        [Column("gen_nome")]
        public string Name { get; set; }
    }
}
