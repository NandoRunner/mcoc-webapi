using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class ActorMovie
    {
        [Key]
        public long? ActorId { get; set; }
        [Key]
        public long? MovieId { get; set; }
    }
}
