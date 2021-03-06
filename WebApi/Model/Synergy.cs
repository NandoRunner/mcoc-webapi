﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_synergy")]
    public class Synergy : BaseEntity {

        [DataMember(Order = 3)]
        public string allBonus { get; set; }

        [DataMember(Order = 4)]
        public int star { get; set; }

        [DataMember(Order = 5)]
        public string parentBonus { get; set; }

        [DataMember(Order = 6)]
        public string childBonus { get; set; }
    }
}
