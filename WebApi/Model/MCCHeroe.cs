using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_heroe")]
    public class MccHeroe : BaseEntity {

         public int heroe_class { get; set; }
    }
}
