using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccUsersController : Controller
    {
        //Declaração do serviço usado
        private IMccUserBusiness _mccUserBusiness;
        
        /* Injeção de uma instancia de IMccUserBusiness ao criar
        uma instancia de ActorController */
        public MccUsersController(IMccUserBusiness usrBusiness)
        {
            _mccUserBusiness = usrBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccUserBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var usr = _mccUserBusiness.FindById(id);
            if (usr == null) return NotFound();
            return Ok(usr);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccUserBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]MccUser usr)
        {
            if (usr == null) return BadRequest();
            return new  ObjectResult(_mccUserBusiness.Create(usr));
        }

        [HttpPut]
        public IActionResult Put([FromBody]MccUser usr)
        {
            if (usr == null) return BadRequest();
            var updatedItem = _mccUserBusiness.Update(usr);
            if (updatedItem == null) return NoContent(); 
            return new ObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mccUserBusiness.Delete(id);
            return NoContent();
        }
    }
}
