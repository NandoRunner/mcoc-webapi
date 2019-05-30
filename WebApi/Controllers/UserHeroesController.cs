using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class UserHeroesController : Controller
    {
        //Declaração do serviço usado
        private IUserHeroeBusiness _mccBusiness;
        
        public UserHeroesController(IUserHeroeBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<UserHeroe>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserHeroe), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var item = _mccBusiness.FindByIdA(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
      
        [HttpPost]
        [ProducesResponseType(typeof(UserHeroe), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]UserHeroe item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccBusiness.Create(item));
        }


    }
}
