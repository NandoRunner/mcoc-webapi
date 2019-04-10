using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_user_alliance")]
    public class MccUserAlliance : BaseInterEntity {

        public DateTime start_date { get; set; }

        public DateTime? end_date { get; set; }

    }
}
