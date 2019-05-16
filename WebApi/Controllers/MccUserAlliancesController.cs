﻿using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MccUserAlliancesController : Controller
    {
        //Declaração do serviço usado
        private IMccUserAllianceBusiness _mccUserAllianceBusiness;
        
        public MccUserAlliancesController(IMccUserAllianceBusiness itemBusiness)
        {
            _mccUserAllianceBusiness = itemBusiness;
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mccUserAllianceBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _mccUserAllianceBusiness.FindByIdA(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

      
        [HttpPost]
        public IActionResult Post([FromBody]MccUserAlliance item)
        {
            if (item == null) return BadRequest();
            return new  ObjectResult(_mccUserAllianceBusiness.Create(item));
        }


    }
}
