﻿using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Business;
using WebApi.Data.VO;
using System.Collections.Generic;

namespace WebApi.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class McocHeroesController : Controller
    {
        //Declaração do serviço usado
        private IMccHeroeBusiness _mccBusiness;

        /* Injeção de uma instancia de IMccHeroeBusiness ao criar
        uma instancia de ActorController */
        public McocHeroesController(IMccHeroeBusiness itemBusiness)
        {
            _mccBusiness = itemBusiness;
        }

        public McocHeroesController()
        {
        }

        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return new OkObjectResult(_mccBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var item = _mccBusiness.FindById(id);
            if (item == null) return NotFound();
            return new OkObjectResult(item);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var ret = _mccBusiness.FindByName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetByExactName(string name)
        {
            var ret = _mccBusiness.FindByExactName(name);
            if (ret == null) return NotFound();
            return Ok(ret);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]MccHeroeVO item)
        {
            if (item == null) return BadRequest();
            var createdItem = _mccBusiness.Create(item);
            if (createdItem == null) return BadRequest();
            return new OkObjectResult(createdItem);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostArray([FromBody]MccHeroeVO[] item)
        {
            if (item[0] == null) return BadRequest();

            bool bok = false;
            foreach (MccHeroeVO i in item)
            {
                if (_mccBusiness.Create(i) != null)
                {
                    bok = true;
                }
            }
            if (bok) return Ok();
            else return BadRequest();
        }


        // PASSAR ESSE IMPORT PARA UM OUTRO CONTROLER

        [Route("[action]")]
        [HttpPost]
        public IActionResult PostImport(McocHeroeRequest item)
        {
            if (item == null) return BadRequest();

            MccHeroeVO h = new MccHeroeVO();
            h.Name = item.name;

            var createdItem = _mccBusiness.Create(h);
            if (createdItem == null) return BadRequest();

            // Tratar Hashtags
            MccHashtagVO ht = new MccHashtagVO();
            MccHashtagsController hc = new MccHashtagsController();

            foreach (string s in item.hashtags)
            {
                ht.Name = s;
                var ret = hc.Post(ht);

                // Implementar heroe/hashtag
                //...
                //...
            }

            return Ok();
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]MccHeroeVO item)
        {
            if (item == null) return BadRequest();
            var updatedItem = _mccBusiness.Update(item);
            if (updatedItem == null) return NoContent(); 
            return new OkObjectResult(updatedItem);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _mccBusiness.Delete(id);
            return NoContent();
        }
    }
}
