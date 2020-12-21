using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("vw_heroe_per_ability")]
    public class HeroePerAbility : BaseView
    {
        [DataMember(Order = 4)]
        public int abilityType { get; set; }

    }
}
