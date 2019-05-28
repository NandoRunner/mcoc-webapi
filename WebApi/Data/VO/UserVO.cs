using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace WebApi.Data.VO
{
    public class UserVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
