using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;
namespace WebApi.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/genre/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Genre]Controller
    e expõe como endpoint REST
    */
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        //Declaração do serviço usado
        private IGenreService _genreService;

        /* Injeção de uma instancia de IGenreService ao criar
        uma instancia de GenreController */
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/genre/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genreService.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/genre/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var genre = _genreService.FindById(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/genre/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost]
        public IActionResult Post([FromBody]Genre genre)
        {
            if (genre == null) return BadRequest();
            return new  ObjectResult(_genreService.Create(genre));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/genre/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        //[HttpPut("{id}")]
        //public IActionResult Put([FromBody]Genre genre)
        //{
        //    if (genre == null) return BadRequest();
        //    return new ObjectResult(_genreService.Update(genre));
        //}


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/genre/{id}
        //recebendo um ID como no Path da requisição
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _genreService.Delete(id);
        //    return NoContent();
        //}
    }
}
