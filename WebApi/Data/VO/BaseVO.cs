using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace WebApi.Data.VO
{
    [DataContract]
    public class BaseVO 
        //: ISupportsHyperMedia
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        //[DataMember(Order = 4)]
        //public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
