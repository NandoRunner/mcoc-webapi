using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Model.Base
{
    //[DataContract]
    public class BaseView
    {
        [Key]
        public string Name { get; set; }

        public long Filmes { get; set; }
    }
}
