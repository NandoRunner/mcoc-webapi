using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class _vw_mc_filme_ver
    {
        [Key]
        public long id { get; set; }

        public string titulo { get; set; }

        public long ano { get; set; }

        public decimal rating { get; set; }
    }
}
