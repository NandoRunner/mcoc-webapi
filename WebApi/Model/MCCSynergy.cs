using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_synergy")]
    public class MccSynergy : BaseEntity {

        [DataMember(Order = 3)]
        public string all_bonus { get; set; }

        [DataMember(Order = 4)]
        public int star { get; set; }

        [DataMember(Order = 5)]
        public string parent_bonus { get; set; }

        [DataMember(Order = 6)]
        public string child_bonus { get; set; }
    }
}
