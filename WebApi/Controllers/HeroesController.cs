using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebApi.Model.Base;
using Microsoft.AspNetCore.Cors;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    [EnableCors("AllowOrigin")]
    public class HeroesController : Controller
    {
        //Declaração do serviço usado
        private IHeroeBusiness _business;

        /* Injeção de uma instancia de IMccHeroeBusiness ao criar
        uma instancia de Controller */
        public HeroesController(IHeroeBusiness itemBusiness)
        {
            _business = itemBusiness;
        }
        
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<HeroeVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int heroe_class = (int)enHeroeClass.ALL)
        {
            //return new OkObjectResult(_mccBusiness.FindAll());

            var ret = _business.FindAll((enHeroeClass)heroe_class);
            if (ret == null) return NotFound();
            ResponseVO<HeroeVO> vr = new ResponseVO<HeroeVO>();
            vr.server_response = ret;
            return Ok(vr);


        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HeroeVO), 200)]
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
        [ProducesResponseType(typeof(List<HeroeVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByName(string name, int heroe_class = (int)enHeroeClass.ALL)
        {
            var ret = _business.FindByName(name, (enHeroeClass)heroe_class);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(HeroeVO), 200)]
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
        [ProducesResponseType(typeof(HeroeVO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]HeroeVO item)
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
        public IActionResult PostArray([FromBody]HeroeVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach (HeroeVO i in item)
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
        [ProducesResponseType(typeof(HeroeVO), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]HeroeVO item)
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

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(List<HeroePerClass>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetHeroeCountPerClass()
        {
            //return new OkObjectResult(_mccBusiness.FindAll());

            var ret = _business.FindAll();
            if (ret == null) return NotFound();
              return Ok(ret);


        }
    }
}
