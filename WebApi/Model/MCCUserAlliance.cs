﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_user_alliance")]
    public class MccUserAlliance : BaseInterEntity {

        [DataMember(Order = 3)]
        public DateTime start_date { get; set; }

        [DataMember(Order = 4)]
        public DateTime? end_date { get; set; }

    }
}
