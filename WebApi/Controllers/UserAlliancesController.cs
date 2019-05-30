using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class UserAlliancesController : Controller
    {
        //Declaração do serviço usado
        private IUserAllianceBusiness _mccBusiness;
        
        public UserAlliancesController(IUserAllianceBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<UserAlliance>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserAlliance), 200)]
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
        [ProducesResponseType(typeof(UserAlliance), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]UserAlliance item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccBusiness.Create(item));
        }


    }
}
