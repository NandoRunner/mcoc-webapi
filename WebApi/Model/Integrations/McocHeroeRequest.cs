using System;
using System.Collections.Generic;


namespace WebApi.Model.Integrations
{
    public class McocHeroeRequest
    {
        public string name { get; set; }
        
        public string uniqueName { get; set; }

        public string shortName { get; set; }

        public string heroeClass { get; set; }

        public DateTime released { get; set; }

        public string stars { get; set; }

        public string infopage { get; set; }

        public List<string> abilities { get; set; }

        public List<string> extAbilities { get; set; }

        public List<string> counters { get; set; }

        public List<string> hashtags { get; set; }

        public McocHeroeRequest()
        {
            //star = new string[6];
            stars = string.Empty;
        }
    }
}
