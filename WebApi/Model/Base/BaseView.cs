using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Model.Base
{
    [DataContract]
    public class BaseView
    {
        [DataMember(Order = 1)]
        public int name { get; set; }

        [DataMember(Order = 3)]
        public long qty { get; set; }
    }

}
