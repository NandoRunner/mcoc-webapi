using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_user_alliance")]
    public class UserAlliance : BaseInterEntity {

        [DataMember(Order = 3)]
        public DateTime startDate { get; set; }

        [DataMember(Order = 4)]
        public DateTime? endDate { get; set; }

    }
}
