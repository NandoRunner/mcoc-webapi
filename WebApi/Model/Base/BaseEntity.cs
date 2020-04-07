
using System.Collections.Generic;
using System.Runtime.Serialization;
using WebApi.Data.VO;

namespace WebApi.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember(Order = 1)]
        public long? id { get; set; }

        [DataMember(Order = 2)]
        public string name { get; set; }

        
    }

    public class ResponseVO<T> where T : BaseVO
    {
        public List<T> serverResponse { get; set; }
    }

}
