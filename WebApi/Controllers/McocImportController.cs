using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using WebApi.Model.Integrations;
using McocApi.Util;

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
        private ILog _logger;

        private Dictionary<string, int> nvc;

        public McocImportController(IHeroeBusiness hBusiness, IAbilityBusiness abBusiness,
            IHashtagBusiness htBusiness, IHeroeHashtagBusiness hhtBusiness, IHeroeAbilityBusiness habBusiness, ILog logger)
        {
            _heroe = hBusiness;
            _ability = abBusiness;
            _hashtag = htBusiness;
            _heroeHashtag = hhtBusiness;
            _heroeAbility = habBusiness;
            _logger = logger;

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
                heroeClass = nvc[item.heroeClass],
                releaseDate = item.released,
                infoPage = item.infopage,
                stars = item.stars
            };

            var exact_name = _heroe.FindByExactName(item.name);

            if (exact_name.Name != null)
            {
                h.Id = exact_name.Id;

                var updatedItem = _heroe.Update(h);
                if (updatedItem == null) return NoContent();
                return Ok();
            }

            var createdItem = _heroe.FindOrCreate(h);
            if (createdItem == null) return BadRequest();

            this.CreateHeroeHashtag(item.hashtags, ref createdItem);
            this.CreateHeroeAbilities(item.abilities, ref createdItem, 0);
            this.CreateHeroeAbilities(item.extAbilities, ref createdItem, 1);
            this.CreateHeroeAbilities(item.counters, ref createdItem, 2);

            return Ok();
        }

        private void CreateHeroeHashtag(List<string> list, ref HeroeVO createdItem)
        {
            HeroeHashtag h = new HeroeHashtag { idObjectA = createdItem.Id ?? default(long) };

            var errou = false;
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;

                HashtagVO vo = new HashtagVO { Name = s.ToLower() };
                try
                {
                    var ret = _hashtag.FindOrCreate(vo);
                    h.idObjectB = ret.Id ?? default(long);
                    _heroeHashtag.Create(h);
                }
                catch
                {
                    if (!errou)
                    {
                        _logger.Information("> " + createdItem.Name + " - Hashtag");
                        errou = true;
                    }
                    _logger.Error(s);
                }
            }
        }

        private void CreateHeroeAbilities(List<string> list, ref HeroeVO createdItem, int type)
        {
            HeroeAbility h = new HeroeAbility { idObjectA = createdItem.Id ?? default(long) };

            var errou = false; 
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;

                AbilityVO vo = new AbilityVO { Name = s.ToLower(), Type = type };
                try
                {
                    var ret = _ability.FindByExactName(vo.Name, (enAbility)vo.Type);

                    if (ret.Id == null) ret = _ability.Create(vo);

                    h.idObjectB = ret.Id ?? default(long);
                    _heroeAbility.Create(h);
                }
                catch
                {
                    if (!errou)
                    {
                        _logger.Information("> " + createdItem.Name + " - Ability " + type.ToString());
                        errou = true;
                    }
                    _logger.Error(s);
                }
            }
        }


    }
}
