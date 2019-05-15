using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccHashtagsController : Controller
    {
        //Declaração do serviço usado
        private IMccHashtagBusiness _mccBusiness;

        /* Injeção de uma instancia de IMccHashtagBusiness ao criar
        uma instancia de ActorController */
        public MccHashtagsController(IMccHashtagBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        public MccHashtagsController()
        {
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var item = _mccBusiness.FindById(id);
            if (item == null) return NotFound();
            return new OkObjectResult(item);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByExactName(string name)
        {
            var ret = _mccBusiness.FindByExactName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]MccHashtagVO item)
        {
            if (item == null) return BadRequest();
            var createdItem = _mccBusiness.Create(item);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostArray([FromBody]MccHashtagVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach(MccHashtagVO i in item)
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]MccHashtagVO item)
        {
            if (item == null) return BadRequest();
            var updatedItem = _mccBusiness.Update(item);
            if (updatedItem == null) return NoContent(); 
            return new OkObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _mccBusiness.Delete(id);
            return NoContent();
        }
    }
}
