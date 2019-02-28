using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class _vw_mc_ator
    {
        [Key]
        public string Ator { get; set; }

        public long Filmes { get; set; }
    }
}
