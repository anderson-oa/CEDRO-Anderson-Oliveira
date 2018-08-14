using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces.Services;
using System;

namespace RestauranteDDD.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : Controller
    {
        private readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pratoService.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_pratoService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Adicionar([FromBody]JObject prato)
        {
            try
            {
                _pratoService.Adicionar(prato.ToObject<Prato>());
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Atualizar([FromBody]JObject prato)
        {
            try
            {
                _pratoService.Atualizar(prato.ToObject<Prato>());
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pratoService.Deletar(id);
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _pratoService.Dispose();
            base.Dispose(disposing);
        }
    }
}