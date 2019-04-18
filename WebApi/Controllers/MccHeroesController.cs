using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;

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
        public MccHeroesController(IMccHeroeBusiness itemBusiness)
        {
            _mccHeroeBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_mccHeroeBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var item = _mccHeroeBusiness.FindById(id);
            if (item == null) return NotFound();
            return new OkObjectResult(item);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccHeroeBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByExactName(string name)
        {
            var ret = _mccHeroeBusiness.FindByExactName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]MccHeroeVO item)
        {
            if (item == null) return BadRequest();
            var createdItem = _mccHeroeBusiness.Create(item);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostArray([FromBody]MccHeroeVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach (MccHeroeVO i in item)
            {
                if (_mccHeroeBusiness.Create(i) != null)
                {
                    bok = true;
                }
            }
            if (bok) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]MccHeroeVO item)
        {
            if (item == null) return BadRequest();
            var updatedItem = _mccHeroeBusiness.Update(item);
            if (updatedItem == null) return NoContent(); 
            return new OkObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _mccHeroeBusiness.Delete(id);
            return NoContent();
        }
    }
}
