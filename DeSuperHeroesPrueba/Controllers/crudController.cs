﻿using System;
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
        private readonly facturaciones _servicioFactura;
        private readonly entradas _servicioEntrada;



        public crudController(ClienteCRUD servicioCliente, ProductoCRUD servicioProducto, ProveedorCRUD servicioProveedor, facturaciones servicioFactura, entradas servicioEntrada)
        {
            _servicioCliente = servicioCliente;
            _servicioProducto = servicioProducto;
            _servicioProveedor = servicioProveedor;
            _servicioEntrada = servicioEntrada;
            _servicioFactura = servicioFactura;
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

        [HttpPut]
        [Route("editar_cliente")]
        public IActionResult editCliente([FromBody]Cliente _cliente)
        {
           
            var editar = _servicioCliente.editCliente(_cliente);

            if (editar)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar_cliente/{id}")]
        public IActionResult deleteCliente(int id)
        {

            var eliminar = _servicioCliente.DeleteCliente(id);

            if (eliminar)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //apartado de metodos para el manejo de productos

        [HttpGet]
        [Route("Obtener_productos")]
        public IActionResult getProductos()
        {
            var resultado = _servicioProducto.Obtener();
            return Ok(resultado);
        }
       


        [HttpPost]
        [Route("agregar_productos")]
        public IActionResult addProductos([FromBody]producto _producto)
        {
            var resultado = _servicioProducto.AddProducto(_producto);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("eliminar_productos/{productoid}")]

        public IActionResult deleteProductos(int productoid)
        {
            var resultado = _servicioProducto.Deleteproducto(productoid);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //apartado de metodos para el manejo de proveedores
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
        }

        //Agregar entradas y facturaciones
        [HttpPost]
        [Route("agregar_factura")]
        public IActionResult addFactura([FromBody]producto_cliente _compra)
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

        [HttpPost]
        [Route("agregar_entrada")]
        public IActionResult addEntrada([FromBody]producto_proveedor _importar)
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

