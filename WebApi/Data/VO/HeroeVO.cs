using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace WebApi.Data.VO
{
    public class HeroeVO : BaseVO
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
