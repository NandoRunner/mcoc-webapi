using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/movie/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Movie]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MoviesController : Controller
    {
        //Declaração do serviço usado
        private IMovieBusiness _movieBusiness;

        /* Injeção de uma instancia de IMovieBusiness ao criar
        uma instancia de MovieController */
        public MoviesController(IMovieBusiness movieBusiness)
        {
            _movieBusiness = movieBusiness;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/movie/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieBusiness.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/movie/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var movie = _movieBusiness.FindById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
		
        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _movieBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
		
        [Route("[action]/{order}")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetWatched(int order = (int)enMovieCount.periodo)
        {
            var ret = _movieBusiness.FindWatched((enMovieCount)order);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{order}")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAvailable(int order = (int)enMovieCount.rating)
        {
            var ret = _movieBusiness.FindAvailable((enMovieCount)order);
            if (ret == null) return NotFound();
            return Ok(ret);
        }


        //Mapeia as requisições POST para http://localhost:{porta}/api/movie/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            if (movie == null) return BadRequest();
            return new  ObjectResult(_movieBusiness.Create(movie));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/movie/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        //[HttpPut("{id}")]
        //public IActionResult Put([FromBody]Movie movie)
        //{
        //    if (movie == null) return BadRequest();
        //    return new ObjectResult(_movieBusiness.Update(movie));
        //}


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/movie/{id}
        //recebendo um ID como no Path da requisição
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _movieBusiness.Delete(id);
        //    return NoContent();
        //}
    }
}
