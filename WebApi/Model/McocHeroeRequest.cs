using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class McocHeroeRequest
    {
        public string name { get; set; }

        public string unique_name { get; set; }

        public string short_name { get; set; }

        public string heroe_class { get; set; }

        public DateTime released { get; set; }

        public string[] star { get; set; }

        public List<string> abilities { get; set; }

        public List<string> ext_abilities { get; set; }

        public List<string> counters { get; set; }

        public List<string> hashtags { get; set; }

        public McocHeroeRequest()
        {
            star = new string[6];
        }
    }
}
