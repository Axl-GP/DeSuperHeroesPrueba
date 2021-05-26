using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        [HttpPost]
        [Route("agregar_entrada")]
        public IActionResult addEntrada([FromBody] producto_proveedor _importar)
        {
            var resultado = _servicioEntrada.AddEntrada(_importar);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
