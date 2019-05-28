using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class HeroeAbilitysController : Controller
    {
        //Declaração do serviço usado
        private IHeroeAbilityBusiness _mccBusiness;
        
        public HeroeAbilitysController(IHeroeAbilityBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<HeroeAbility>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HeroeAbility), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var item = _mccBusiness.FindByIdA(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

     
        [HttpPost]
        [ProducesResponseType(typeof(HeroeAbility), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]HeroeAbility item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccBusiness.Create(item));
        }


    }
}
