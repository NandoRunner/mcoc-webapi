using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/director/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Director]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class DirectorsController : Controller
    {
        //Declaração do serviço usado
        private IDirectorBusiness _directorService;

        /* Injeção de uma instancia de IDirectorService ao criar
        uma instancia de DirectorController */
        public DirectorsController(IDirectorBusiness directorService)
        {
            _directorService = directorService;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/director/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_directorService.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/director/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var director = _directorService.FindById(id);
            if (director == null) return NotFound();
            return Ok(director);
        }
        
        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _directorService.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{order}")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetMovieCount(int order = (int)enMovieCount.count)
        {
            var ret = _directorService.FindMovieCount((enMovieCount)order);
            if (ret == null) return NotFound();
            DirectorResponse ar = new DirectorResponse();
            ar.server_response = ret;
            return Ok(ar);
        }
        //Mapeia as requisições POST para http://localhost:{porta}/api/director/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody]Director director)
        {
            if (director == null) return BadRequest();
            return new  ObjectResult(_directorService.Create(director));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/director/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Director director)
        {
            if (director == null) return BadRequest();
            var updatedDirector = _directorService.Update(director);
            if (updatedDirector == null) return NoContent();
            return new ObjectResult(updatedDirector);
        }


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/director/{id}
        //recebendo um ID como no Path da requisição
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _directorService.Delete(id);
            return NoContent();
        }
    }
}
