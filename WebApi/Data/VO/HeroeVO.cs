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
        public int heroe_class { get; set; }

    }
}
