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
    public class ProvidersController : ControllerBase
    {
        /*
        [HttpGet]
        [Route("Obtener_proveedores")]
        public IActionResult getProveedores()
        {
            var resultado = _servicioProveedor.Obtener();
            return Ok(resultado);
        }




        [HttpPost]
        [Route("agregar_proveedores")]
        public IActionResult addProveedor([FromBody] proveedor proveedor)
        {
            var resultado = _servicioProveedor.AddProveedor(proveedor);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("editar_proveedores")]

        public IActionResult editProveedores([FromBody] proveedor _proveedor)
        {
            var resultado = _servicioProveedor.editProveedor(_proveedor);
            if (resultado)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("eliminar_proveedores/{idProveedor}")]

        public IActionResult deleteProveedores(int idProveedor)
        {

            var resultado = _servicioProveedor.DeleteProveedor(idProveedor);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }*/

    }
}
