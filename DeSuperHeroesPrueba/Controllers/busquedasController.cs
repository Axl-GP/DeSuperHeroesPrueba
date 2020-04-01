﻿using System;
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
    public class busquedasController : ControllerBase
    {

        private readonly ClienteCRUD _servicioCliente;
        private readonly ProductoCRUD _servicioProducto;
        private readonly ProveedorCRUD _servicioProveedor;

        public busquedasController(ClienteCRUD servicioCliente, ProductoCRUD servicioProducto, ProveedorCRUD servicioProveedor)
        {
            _servicioCliente = servicioCliente;
            _servicioProducto = servicioProducto;
            _servicioProveedor = servicioProveedor;
        }
        //Busquedas de productos
        [HttpGet]
        [Route("Obtener_productos/{id}")]
        public IActionResult getProductos(int id)
        {
            var resultado = _servicioProducto.ObtenerID(id);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_productos_nombre/{nombre}")]
        public IActionResult getProductos(string nombre)
        {
            var resultado = _servicioProducto.ObtenerNombre(nombre);
            return Ok(resultado);
        }

        //Busquedas de clientes


        //Busquedas de proveedor

        [HttpGet]
        [Route("Obtener_proveedores/{id}")]
        public IActionResult getProveedores(int id)
        {
            var resultado = _servicioProveedor.Obtener(id);
            return Ok(resultado);
        }
    }
}