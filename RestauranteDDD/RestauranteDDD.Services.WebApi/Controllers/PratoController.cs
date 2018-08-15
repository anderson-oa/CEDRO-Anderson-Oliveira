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

        /// <summary>
        /// Consultar os pratos cadastrados
        /// </summary>
        /// <returns>Retorna todos os pratos cadastrados</returns>
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

        /// <summary>
        /// Consultar prato por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um prato</returns>
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

        /// <summary>
        /// Adicionar prato
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Prato
        ///     {
        ///        "pratoId": 1,
        ///        "nome": "Nome do prato",
        ///        "preco":"1.00",
        ///        "restauranteId":"2"
        ///     }       
        /// </remarks>
        /// <param name="prato"></param>      
        /// <returns>Mensagem de sucesso ou de error</returns>
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

        /// <summary>
        /// Atualizar informações do prato
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Prato
        ///     {
       ///         "pratoId": 1,
        ///        "nome": "Nome do prato",
        ///        "preco":"1.00",
        ///        "restauranteId":"2"
        ///     }       
        /// </remarks>
        /// <param name="prato"></param>      
        /// <returns>Mensagem de sucesso ou de error</returns>    
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

        /// <summary>
        /// Deletar prato por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mensagem de sucesso ou de error</returns>     
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