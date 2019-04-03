﻿using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
namespace WebApi.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/actor/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Actor]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ActorsController : Controller
    {
        //Declaração do serviço usado
        private IActorBusiness _actorBusiness;
        
        /* Injeção de uma instancia de IActorBusiness ao criar
        uma instancia de ActorController */
        public ActorsController(IActorBusiness actorBusiness)
        {
            _actorBusiness = actorBusiness;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/actor/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorBusiness.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/actor/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var actor = _actorBusiness.FindById(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _actorBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }
        
        [Route("[action]/{order}")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetMovieCount(int order = (int)enMovieCount.count)
        {
            var ret = _actorBusiness.FindMovieCount((enMovieCount)order);
            if (ret == null) return NotFound();
            ActorResponse ar = new ActorResponse();
            ar.server_response = ret;
            return Ok(ar);
        }


        //Mapeia as requisições POST para http://localhost:{porta}/api/actor/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        //[HttpPost("v{version:apiVersion}")]
        public IActionResult Post([FromBody]Actor actor)
        {
            if (actor == null) return BadRequest();
            return new  ObjectResult(_actorBusiness.Create(actor));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/actor/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        //[HttpPut("v{version:apiVersion}")]
        public IActionResult Put([FromBody]Actor actor)
        {
            if (actor == null) return BadRequest();
            var updatedActor = _actorBusiness.Update(actor);
            if (updatedActor == null) return NoContent(); 
            return new ObjectResult(updatedActor);
        }


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/actor/{id}
        //recebendo um ID como no Path da requisição
        //[HttpDelete("v{version:apiVersion}/{id}")]
        public IActionResult Delete(int id)
        {
            _actorBusiness.Delete(id);
            return NoContent();
        }
    }
}
