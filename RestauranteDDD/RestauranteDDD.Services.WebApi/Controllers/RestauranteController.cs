using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces.Services;
using System;

namespace RestauranteDDD.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _restauranteService;

        public RestauranteController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_restauranteService.ObterTodos());
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
                return Ok(_restauranteService.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Adicionar([FromBody]JObject restaurante)
        {
            try
            {                           
                _restauranteService.Adicionar(restaurante.ToObject<Restaurante>());
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult Atualizar([FromBody]JObject restaurante)
        {
            try
            {
                _restauranteService.Atualizar(restaurante.ToObject<Restaurante>());
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
                _restauranteService.Deletar(id);
                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _restauranteService.Dispose();
            base.Dispose(disposing);
        }
    }
}