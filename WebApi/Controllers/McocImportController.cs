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
            this.CreateHeroeAbility(ref item, ref createdItem);
            this.CreateHeroeExtAbility(ref item, ref createdItem);
            this.CreateHeroeCounters(ref item, ref createdItem);

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


        private void CreateHeroeAbility(ref McocHeroeRequest item, ref HeroeVO createdItem)
        {
            HeroeAbility h = new HeroeAbility { id_a = createdItem.Id ?? default(long) };

            foreach (string s in item.abilities)
            {
                if (string.IsNullOrEmpty(s)) continue;

                AbilityVO vo = new AbilityVO { Name = s, Type = 0 };
                //var ret = _ability.FindOrCreate(vo);

                var ret = _ability.FindByExactName(s, 0);
                
                if (ret == null)
                    ret = _ability.Create(vo);

                h.id_b = ret.Id ?? default(long);
                _heroeAbility.Create(h);
            }
        }

        private void CreateHeroeExtAbility(ref McocHeroeRequest item, ref HeroeVO createdItem)
        {
            HeroeAbility h = new HeroeAbility { id_a = createdItem.Id ?? default(long) };

            foreach (string s in item.ext_abilities)
            {
                if (string.IsNullOrEmpty(s)) continue;

                AbilityVO vo = new AbilityVO { Name = s, Type = 1 };
                //var ret = _ability.FindOrCreate(vo);

                var ret = _ability.FindByExactName(s, 1);

                if (ret == null)
                    ret = _ability.Create(vo);

                h.id_b = ret.Id ?? default(long);
                _heroeAbility.Create(h);
            }
        }

        private void CreateHeroeCounters(ref McocHeroeRequest item, ref HeroeVO createdItem)
        {
            HeroeAbility h = new HeroeAbility { id_a = createdItem.Id ?? default(long) };

            foreach (string s in item.counters)
            {
                if (string.IsNullOrEmpty(s)) continue;

                AbilityVO vo = new AbilityVO { Name = s, Type = 2 };
                //var ret = _ability.FindOrCreate(vo);

                var ret = _ability.FindByExactName(s, 2);

                if (ret == null)
                    ret = _ability.Create(vo);

                h.id_b = ret.Id ?? default(long);
                _heroeAbility.Create(h);
            }
        }

    }
}
