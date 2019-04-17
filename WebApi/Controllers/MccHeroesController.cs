using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccHeroesController : Controller
    {
        //Declaração do serviço usado
        private IMccHeroeBusiness _mccHeroeBusiness;

        /* Injeção de uma instancia de IMccHeroeBusiness ao criar
        uma instancia de ActorController */
        public MccHeroesController(IMccHeroeBusiness usrBusiness)
        {
            _mccHeroeBusiness = usrBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccHeroeBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var usr = _mccHeroeBusiness.FindById(id);
            if (usr == null) return NotFound();
            return Ok(usr);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccHeroeBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]MccHeroe usr)
        {
            if (usr == null) return BadRequest();
            return new  ObjectResult(_mccHeroeBusiness.Create(usr));
        }

        [HttpPut]
        public IActionResult Put([FromBody]MccHeroe usr)
        {
            if (usr == null) return BadRequest();
            var updatedItem = _mccHeroeBusiness.Update(usr);
            if (updatedItem == null) return NoContent(); 
            return new ObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mccHeroeBusiness.Delete(id);
            return NoContent();
        }
    }
}
