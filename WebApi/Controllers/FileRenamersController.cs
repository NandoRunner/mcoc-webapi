using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApi.Model;
using WebApi.Integrations.Model;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}")]
    public class FileRenamersController : Controller
    {
        //Declaração do serviço usado
        private IFileRenamerBusiness _business;

        /* Injeção de uma instancia de IMccFileRenamerBusiness ao criar
        uma instancia de Controller */
        public FileRenamersController(IFileRenamerBusiness itemBusiness)
        {
            _business = itemBusiness;
        }
        
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [ProducesResponseType(typeof(List<FileRenamer>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return new OkObjectResult(_business.FindAll());
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(List<FileRenamerRequest>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetImport()
        {
            return new OkObjectResult(_business.FindAllRequest());
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult PostImport([FromBody]FileRenamerRequest item)
        {
            if (item == null) return BadRequest();

            FileRenamer fr = new FileRenamer
            {
                caminho = item.caminho,
                extensao = item.extensao,
                prefixo = item.prefixo,
                substituir = item.substituir,
                substpor = item.substpor,
                abreviar = item.abreviar 
            };

            var createdItem = _business.Create(fr);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

       


    }
}
