using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccAlliancesController : Controller
    {
        //Declaração do serviço usado
        private IMccAllianceBusiness _mccAllianceBusiness;
        
        /* Injeção de uma instancia de IMccAllianceBusiness ao criar
        uma instancia de ActorController */
        public MccAlliancesController(IMccAllianceBusiness alyBusiness)
        {
            _mccAllianceBusiness = alyBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccAllianceBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var aly = _mccAllianceBusiness.FindById(id);
            if (aly == null) return NotFound();
            return Ok(aly);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccAllianceBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]MccAlliance aly)
        {
            if (aly == null) return BadRequest();
            return new  ObjectResult(_mccAllianceBusiness.Create(aly));
        }

        [HttpPut]
        public IActionResult Put([FromBody]MccAlliance aly)
        {
            if (aly == null) return BadRequest();
            var updatedItem = _mccAllianceBusiness.Update(aly);
            if (updatedItem == null) return NoContent(); 
            return new ObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mccAllianceBusiness.Delete(id);
            return NoContent();
        }
    }
}
