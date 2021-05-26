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
    public class SellsController : ControllerBase
    {
        [HttpPost]
        [Route("agregar_factura")]
        public IActionResult addFactura([FromBody] producto_cliente _compra)
        {
            var resultado = _servicioFactura.Addfactura(_compra);
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
