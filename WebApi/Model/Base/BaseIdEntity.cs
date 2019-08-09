
using System.Runtime.Serialization;

namespace WebApi.Model.Base
{
    [DataContract]
    public class BaseIdEntity
    {
        [DataMember(Order = 1)]
        public long? id { get; set; }
        
    }
}
