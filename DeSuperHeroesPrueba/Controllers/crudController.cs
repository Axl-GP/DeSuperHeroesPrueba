using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeSuperHeroesPrueba.Models;
using DeSuperHeroesPrueba.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeSuperHeroesPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class crudController : ControllerBase
    {
        //Definicion de variables para la lectura de los servicios
         
        private readonly ClienteCRUD _servicioCliente;
        private readonly ProductoCRUD _servicioProducto;
        private readonly ProveedorCRUD _servicioProveedor;

        public crudController(ClienteCRUD servicioCliente, ProductoCRUD servicioProducto, ProveedorCRUD servicioProveedor)
        {
            _servicioCliente = servicioCliente;
            _servicioProducto = servicioProducto;
            _servicioProveedor = servicioProveedor;
        }

        //apartado de metodos para el manejo de clientes
        [HttpGet]
        [Route("Obtener_clientes")]
        public IActionResult getClientes()
        {
            var resultado = _servicioCliente.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar_clientes")]
        public IActionResult AddCliente([FromBody] Cliente _cliente)
        {
            try
            {
                var resultado = _servicioCliente.addCliente(_cliente);

                if (resultado)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HelpLink);
                return BadRequest();
            }
            return Ok();
          
        }

        //apartado de metodos para el manejo de productos

        [HttpGet]
        [Route("Obtener_productos")]
        public IActionResult getProductos()
        {
            var resultado = _servicioProducto.Obtener();
            return Ok(resultado);
        }
        //apartado de metodos para el manejo de productos
        [HttpGet]
        [Route("Obtener_proveedores")]
        public IActionResult getProveedores()
        {
            var resultado = _servicioProveedor.Obtener();
            return Ok(resultado);
        }
    }

   

  
}

