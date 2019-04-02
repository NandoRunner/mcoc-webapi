using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("mc_dir_diretor")]
    public class Director
    {
        [Key]
        [Column("dir_diretor_id")]
        public long? Id { get; set; }
        [Column("dir_nome")]
        public string Name { get; set; }
    }
}
