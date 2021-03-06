﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_ability")]
    public class Ability : BaseEntity {

        [DataMember(Order = 3)]
        public int type { get; set; }
    }
}
