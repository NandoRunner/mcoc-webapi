using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using WebApi.Integrations.Model;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class McocImportController : Controller
    {
        //Declaração do serviço usado
        private IHeroeBusiness _heroe;
        private IAbilityBusiness _ability;
        private IHashtagBusiness _hashtag;
        private IHeroeHashtagBusiness _heroeHashtag;
        private IHeroeAbilityBusiness _heroeAbility;

        private Dictionary<string,int> nvc;

        public McocImportController(IHeroeBusiness hBusiness, IAbilityBusiness abBusiness, 
            IHashtagBusiness htBusiness, IHeroeHashtagBusiness hhtBusiness, IHeroeAbilityBusiness habBusiness)
        {
            _heroe = hBusiness;
            _ability = abBusiness;
            _hashtag = htBusiness;
            _heroeHashtag = hhtBusiness;
            _heroeAbility = habBusiness;

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

            var createdItem = _heroe.FindOrCreate(h);
            if (createdItem == null) return BadRequest();

            this.CreateHeroeHashtag(ref item, ref createdItem);
            this.CreateHeroeAbilities(item.abilities, ref createdItem, 0);
            this.CreateHeroeAbilities(item.ext_abilities, ref createdItem, 1);
            this.CreateHeroeAbilities(item.counters, ref createdItem, 2);

            return Ok();
        }

        private void CreateHeroeHashtag(ref McocHeroeRequest item, ref HeroeVO createdItem)
        { 
            HeroeHashtag h = new HeroeHashtag { id_a = createdItem.Id ?? default(long) };

            foreach (string s in item.hashtags)
            {
                if (string.IsNullOrEmpty(s)) continue;

                HashtagVO vo = new HashtagVO { Name = s };
                var ret = _hashtag.FindOrCreate(vo);

                h.id_b = ret.Id ?? default(long);
                _heroeHashtag.Create(h);
            }
        }


        private void CreateHeroeAbilities(List<string> list, ref HeroeVO createdItem, int type)
        {
            HeroeAbility h = new HeroeAbility { id_a = createdItem.Id ?? default(long) };

            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;

                AbilityVO vo = new AbilityVO { Name = s, Type = type };
                var ret = _ability.FindByExactName(vo.Name, vo.Type);
                
                if (ret.Id == null) ret = _ability.Create(vo);

                h.id_b = ret.Id ?? default(long);
                _heroeAbility.Create(h);
            }
        }
               

    }
}
