using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("marvel_heroe")]
    public class Heroe : BaseEntity
    {

        [DataMember(Order = 3)]
        public int heroeClass { get; set; }

        [DataMember(Order = 4)]
        public DateTime ?releaseDate { get; set; }

        [DataMember(Order = 5)]
        public string infoPage { get; set; }

        [DataMember(Order = 6)]
        public string stars { get; set; }
    }
}
