using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_heroe")]
    public class MccHeroe : BaseEntity {

        [DataMember(Order = 3)]
        public int heroe_class { get; set; }
    }
}
