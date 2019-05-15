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
        public string nome { get; set; }

        public long filmes { get; set; }
    }


    public class BaseViewMovie
    {
        [Key]
        public long id { get; set; }

        public string titulo { get; set; }

        public long ano { get; set; }

        public decimal rating { get; set; }
    }

}
