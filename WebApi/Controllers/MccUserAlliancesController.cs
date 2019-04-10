using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccUserAlliancesController : Controller
    {
        //Declaração do serviço usado
        private IMccUserAllianceBusiness _mccUserAllianceBusiness;
        
        /* Injeção de uma instancia de IMccUserAllianceBusiness ao criar
        uma instancia de ActorController */
        public MccUserAlliancesController(IMccUserAllianceBusiness alyBusiness)
        {
            _mccUserAllianceBusiness = alyBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccUserAllianceBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var aly = _mccUserAllianceBusiness.FindByIdA(id);
            if (aly == null) return NotFound();
            return Ok(aly);
        }

        //[Route("[action]/{name}")]
        //[HttpGet]
        //public IActionResult GetByName(string name)
        //{
        //    var ret = _mccUserAllianceBusiness.FindByName(name);
        //    if (ret == null) return NotFound();
        //    return Ok(ret);
        //}
        
        [HttpPost]
        public IActionResult Post([FromBody]MccUserAlliance aly)
        {
            if (aly == null) return BadRequest();
            return new  ObjectResult(_mccUserAllianceBusiness.Create(aly));
        }

        [HttpPut]
        public IActionResult Put([FromBody]MccUserAlliance aly)
        {
            if (aly == null) return BadRequest();
            var updatedItem = _mccUserAllianceBusiness.Update(aly);
            if (updatedItem == null) return NoContent(); 
            return new ObjectResult(updatedItem);
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _mccUserAllianceBusiness.Delete(id);
        //    return NoContent();
        //}
    }
}
