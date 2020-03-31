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
        private readonly ProductoCRUD _servicioProducto;
        private readonly ProveedorCRUD _servicioProveedor;
        public crudController(ClienteCRUD servicioCliente, ProductoCRUD servicioProducto)
        {
            _servicioCliente = servicioCliente;
            _servicioProducto = servicioProducto;
            //_servicioProveedor = servicioProveedor;
        }
        [HttpGet]
        [Route("Obtener_clientes")]
        public IActionResult getClientes()
        {
            var resultado = _servicioCliente.Obtener();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_productos")]
        public IActionResult getProductos()
        {
            var resultado = _servicioProducto.Obtener();
            return Ok(resultado);
        }
    }
}