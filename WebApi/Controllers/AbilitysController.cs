using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    [EnableCors("AllowOrigin")]
    public class AbilitysController : Controller
    {
        //Declaração do serviço usado
        private IAbilityBusiness _business;

        /* Injeção de uma instancia de IMccAbilityBusiness ao criar
        uma instancia de Controller */
        public AbilitysController(IAbilityBusiness itemBusiness)
        {
            _business = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<AbilityVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_business.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AbilityVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var item = _business.FindById(id);
            if (item == null) return NotFound();
            return new OkObjectResult(item);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<AbilityVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByName(string name)
        {
            var ret = _business.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(AbilityVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByExactName(string name)
        {
            var ret = _business.FindByExactName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AbilityVO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]AbilityVO item)
        {
            if (item == null) return BadRequest();
            var createdItem = _business.Create(item);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult PostArray([FromBody]AbilityVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach(AbilityVO i in item)
            {
                if (_business.Create(i) != null)
                {
                    bok = true;
                }
            }
            if (bok) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(AbilityVO), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]AbilityVO item)
        {
            if (item == null) return BadRequest();
            var updatedItem = _business.Update(item);
            if (updatedItem == null) return NoContent(); 
            return new OkObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _business.Delete(id);
            return NoContent();
        }
    }
}
