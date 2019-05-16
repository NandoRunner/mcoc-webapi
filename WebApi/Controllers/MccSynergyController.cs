using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccSynergysController : Controller
    {
        //Declaração do serviço usado
        private IMccSynergyBusiness _mccSynergyBusiness;

        /* Injeção de uma instancia de IMccSynergyBusiness ao criar
        uma instancia de ActorController */
        public MccSynergysController(IMccSynergyBusiness usrBusiness)
        {
            _mccSynergyBusiness = usrBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccSynergyBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var usr = _mccSynergyBusiness.FindById(id);
            if (usr == null) return NotFound();
            return Ok(usr);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccSynergyBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]MccSynergy usr)
        {
            if (usr == null) return BadRequest();
            return new  ObjectResult(_mccSynergyBusiness.Create(usr));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostArray([FromBody]MccSynergy[] item)
        {
            if (item[0] == null) return BadRequest();

            foreach(MccSynergy s in item)
            {
                _mccSynergyBusiness.Create(s);
            }

            return Ok(); 
        }

        [HttpPut]
        public IActionResult Put([FromBody]MccSynergy usr)
        {
            if (usr == null) return BadRequest();
            var updatedItem = _mccSynergyBusiness.Update(usr);
            if (updatedItem == null) return NoContent(); 
            return new ObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mccSynergyBusiness.Delete(id);
            return NoContent();
        }
    }
}
