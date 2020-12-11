using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("vw_heroe_per_hashtag")]
    public class HeroePerHashtag : BaseView
    {
        [DataMember(Order = 2)]
        public string hashtagName { get; set; }

    }
}
