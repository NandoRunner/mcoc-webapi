using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
