using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class HeroeHashtagsController : Controller
    {
        //Declaração do serviço usado
        private IHeroeHashtagBusiness _mccHeroeHashtagBusiness;
        
        public HeroeHashtagsController(IHeroeHashtagBusiness itemBusiness)
        {
            _mccHeroeHashtagBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccHeroeHashtagBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _mccHeroeHashtagBusiness.FindByIdA(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

     
        [HttpPost]
        public IActionResult Post([FromBody]HeroeHashtag item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccHeroeHashtagBusiness.Create(item));
        }


    }
}
