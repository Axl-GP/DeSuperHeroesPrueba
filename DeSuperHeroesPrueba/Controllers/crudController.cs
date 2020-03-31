using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeSuperHeroesPrueba.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeSuperHeroesPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class crudController : ControllerBase
    {
        private readonly ClienteCRUD _servicioCliente;
        public crudController(ClienteCRUD servicio)
        {
            _servicioCliente = servicio;
        }
        [HttpGet]
        [Route("Obtener_clientes")]
        public IActionResult Obtener()
        {
            var resultado = _servicioCliente.Obtener();
            return Ok(resultado);
        }
    }
}