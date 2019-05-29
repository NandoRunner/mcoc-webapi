using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class SynergysController : Controller
    {
        //Declaração do serviço usado
        private ISynergyBusiness _mccBusiness;

        /* Injeção de uma instancia de IMccSynergyBusiness ao criar
        uma instancia de ActorController */
        public SynergysController(ISynergyBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<SynergyVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SynergyVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var item = _mccBusiness.FindById(id);
            if (item == null) return NotFound();
            return new OkObjectResult(item);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<SynergyVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByName(string name)
        {
            var ret = _mccBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(SynergyVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByExactName(string name)
        {
            var ret = _mccBusiness.FindByExactName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SynergyVO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]SynergyVO item)
        {
            if (item == null) return BadRequest();
            var createdItem = _mccBusiness.Create(item);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PostArray([FromBody]SynergyVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach (SynergyVO i in item)
            {
                if (_mccBusiness.Create(i) != null)
                {
                    bok = true;
                }
            }
            if (bok) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(SynergyVO), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]SynergyVO item)
        {
            if (item == null) return BadRequest();
            var updatedItem = _mccBusiness.Update(item);
            if (updatedItem == null) return NoContent(); 
            return new OkObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _mccBusiness.Delete(id);
            return NoContent();
        }
    }
}
