using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    [EnableCors("AllowOrigin")]
    public class HeroeHashtagsController : Controller
    {
        //Declaração do serviço usado
        private IHeroeHashtagBusiness _mccBusiness;
        
        public HeroeHashtagsController(IHeroeHashtagBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<HeroeHashtag>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_mccBusiness.FindAll());
        }
        
        [HttpGet("[action]/{id_b}")]
        [ProducesResponseType(typeof(HeroeHashtag), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetA(long id_b)
        {
            var item = _mccBusiness.FindByIdA(id_b);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{id_a}")]
        [HttpGet]
        [ProducesResponseType(typeof(HeroeHashtag), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetB(long id_a)
        {
            var item = _mccBusiness.FindByIdB(id_a);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{id_b}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Heroe>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetObjectA(long id_b)
        {
            var item = _mccBusiness.FindObjectA(id_b);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Route("[action]/{id_a}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Hashtag>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetObjectB(long id_a)
        {
            var item = _mccBusiness.FindObjectB(id_a);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(HeroeHashtag), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]HeroeHashtag item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccBusiness.Create(item));
        }


    }
}
