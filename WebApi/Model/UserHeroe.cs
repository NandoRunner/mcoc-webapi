using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_user_heroe")]
    public class UserHeroe : BaseInterEntity {

        [DataMember(Order = 3)]
        public int star { get; set; }

        [DataMember(Order = 4)]
        public int rank { get; set; }

        [DataMember(Order = 5)]
        public int level { get; set; }

        [DataMember(Order = 6)]
        public int health { get; set; }

        [DataMember(Order = 7)]
        public int attack { get; set; }

        [DataMember(Order = 8)]
        public int signature { get; set; }

    }
}
