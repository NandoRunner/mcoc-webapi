
using System.Runtime.Serialization;

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
}
