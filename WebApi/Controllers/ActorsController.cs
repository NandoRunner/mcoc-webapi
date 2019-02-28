using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;
namespace WebApi.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/actor/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Actor]Controller
    e expõe como endpoint REST
    */
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        //Declaração do serviço usado
        private IActorService _actorService;

        /* Injeção de uma instancia de IActorService ao criar
        uma instancia de ActorController */
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/actor/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorService.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/actor/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var actor = _actorService.FindById(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/actor/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody]Actor actor)
        {
            if (actor == null) return BadRequest();
            return new  ObjectResult(_actorService.Create(actor));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/actor/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        //[HttpPut("{id}")]
        //public IActionResult Put([FromBody]Actor actor)
        //{
        //    if (actor == null) return BadRequest();
        //    return new ObjectResult(_actorService.Update(actor));
        //}


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/actor/{id}
        //recebendo um ID como no Path da requisição
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _actorService.Delete(id);
        //    return NoContent();
        //}
    }
}
