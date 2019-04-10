using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Model.Base
{
    //[DataContract]
    public class BaseInterEntity
    {
        public long id_a { get; set; }

        public long id_b { get; set; }
    }
}
