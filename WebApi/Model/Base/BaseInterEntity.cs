using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Model.Base
{
    [DataContract]
    public class BaseInterEntity
    {
        [DataMember(Order = 1)]
        public long id_a { get; set; }

        [DataMember(Order = 2)]
        public long id_b { get; set; }
    }
}
