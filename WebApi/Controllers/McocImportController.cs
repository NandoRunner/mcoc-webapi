using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using Mcoc.BusinessRules.Model;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class McocImportController : Controller
    {
        //Declaração do serviço usado
        private IHeroeBusiness _heroeBusiness;
        private IAbilityBusiness _abilityBusiness;
        private IHashtagBusiness _hashtagBusiness;
        private IHeroeHashtagBusiness _heroeHashtagBusiness;

        private Dictionary<string,int> nvc;

        public McocImportController(IHeroeBusiness hBusiness, IAbilityBusiness agBusiness, 
            IHashtagBusiness hashBusiness, IHeroeHashtagBusiness hhashBusiness)
        {
            _heroeBusiness = hBusiness;
            _abilityBusiness = agBusiness;
            _hashtagBusiness = hashBusiness;
            _heroeHashtagBusiness = hhashBusiness;

            nvc = new Dictionary<string, int>
            {
                ["Cosmic"] = Convert.ToInt32(enHeroeClass.Cosmic),
                ["Tech"] = Convert.ToInt32(enHeroeClass.Tech),
                ["Mutant"] = Convert.ToInt32(enHeroeClass.Mutant),
                ["Skill"] = Convert.ToInt32(enHeroeClass.Skill),
                ["Science"] = Convert.ToInt32(enHeroeClass.Science),
                ["Mystic"] = Convert.ToInt32(enHeroeClass.Mystic)
            };
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostImport([FromBody]McocHeroeRequest item)
        {
            if (item == null) return BadRequest();

            HeroeVO h = new HeroeVO
            {
                Name = item.name,
                heroe_class = nvc[item.heroe_class]
            };

            var createdItem = _heroeBusiness.FindOrCreate(h);
            if (createdItem == null) return BadRequest();

            // Tratar Hashtags
            HeroeHashtag hh = new HeroeHashtag
            {
                id_a = createdItem.Id ?? default(long)
            };

            foreach (string s in item.hashtags)
            {
                if (string.IsNullOrEmpty(s)) continue;

                HashtagVO ht = new HashtagVO
                {
                    Name = s
                };
                var ret = _hashtagBusiness.FindOrCreate(ht);

                hh.id_b = ret.Id ?? default(long);
                _heroeHashtagBusiness.Create(hh);
            }

            return Ok();
        }

    }
}
