using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    [EnableCors("AllowOrigin")]
    public class HeroeAbilitysController : Controller
    {
        //Declaração do serviço usado
        private IHeroeAbilityBusiness _business;
        
        public HeroeAbilitysController(IHeroeAbilityBusiness itemBusiness)
        {
            _business = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<HeroeAbility>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_business.FindAll());
        }
        
        [HttpGet("[action]/{idObjectB}")]
        [ProducesResponseType(typeof(HeroeAbility), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetA(long idObjectB)
        {
            var item = _business.FindByIdA(idObjectB);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{idObjectA}")]
        [HttpGet]
        [ProducesResponseType(typeof(HeroeAbility), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetB(long idObjectA)
        {
            var item = _business.FindByIdB(idObjectA);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{idObjectB}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Heroe>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetObjectA(long idObjectB)
        {
            var item = _business.FindObjectA(idObjectB);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{idObjectA}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Ability>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetObjectB(long idObjectA)
        {
            var item = _business.FindObjectB(idObjectA);
            if (item == null) return NotFound();
            return Ok(item);
        }
 
        [HttpPost]
        [ProducesResponseType(typeof(HeroeAbility), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]HeroeAbility item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_business.Create(item));
        }


    }
}
