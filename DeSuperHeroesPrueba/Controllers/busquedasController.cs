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
    public class busquedasController : ControllerBase
    {

        private readonly ClienteCRUD _servicioCliente;
        private readonly ProductoCRUD _servicioProducto;
        private readonly ProveedorCRUD _servicioProveedor;
        private readonly entradas _servicioEntradas;
        private readonly facturaciones _servicioFacturacion;

        public busquedasController(ClienteCRUD servicioCliente,facturaciones servicioFacturacion, entradas servicioEntradas, ProductoCRUD servicioProducto, ProveedorCRUD servicioProveedor)
        {
            _servicioCliente = servicioCliente;
            _servicioProducto = servicioProducto;
            _servicioProveedor = servicioProveedor;
            _servicioEntradas = servicioEntradas;
            _servicioFacturacion = servicioFacturacion;

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

        [HttpGet]
        [Route("Obtener_clientes/{id}")]
        public IActionResult getClientes(int id)
        {
            var resultado = _servicioCliente.Obtener(id);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_clientes_nombre/{nombre}")]
        public IActionResult getClientes(string nombre)
        {
            var resultado = _servicioCliente.Obtener(nombre);

            return Ok(resultado);

        }
        [HttpGet]
        [Route("Obtener_clientes_categoria/{categoria}&&{filtro}")]
        public IActionResult getClientesByCategoria(string categoria, string filtro)
        {
            var resultado = _servicioCliente.ObtenerCategoria(categoria);

            if (filtro.Equals("conteo"))
            {
              
                return Ok(resultado.Count());

            }
            else if (filtro.Equals(""))
            {
                return Ok(resultado);
            }
            return Ok(resultado);



            

        }

        [HttpGet]
        [Route("Obtener_conteo_categoria/{categoria}")]
        public IActionResult getConteoByCategoria(string categoria)
        {
            var resultado = _servicioCliente.ObtenerCategoria(categoria);



            return Ok(resultado.Count());

        }
        //Busquedas de proveedor

        [HttpGet]
        [Route("Obtener_proveedores/{id}")]
        public IActionResult getProveedores(int id)
        {
            var resultado = _servicioProveedor.Obtener(id);
            return Ok(resultado);
        }
        [HttpGet]
        [Route("Obtener_proveedores_nombre/{nombre}")]
        public IActionResult getProveedores(string nombre)
        {
            var resultado = _servicioProveedor.Obtener(nombre);

                return Ok(resultado);
           
        }
        [HttpGet]
        [Route("Obtener_proveedores_email/{email}")]
        public IActionResult getProveedoresbyEmail(string email)
        {
            var resultado = _servicioProveedor.Obtener(email);


            return Ok(resultado);

        }

        //Obtener Entradas

        [HttpGet]
        [Route("Obtener_entrada/")]

        public IActionResult getEntradas()
        {
            var resultado = _servicioEntradas.obtenerEntrada();
            resultado.Count();
            return Ok(resultado);
        }
        [HttpGet]
        [Route("Obtener_entrada/{id}")]

        public IActionResult getEntradas(int id)
        {
            var resultado = _servicioEntradas.obtenerEntrada(id);
            
            
            return Ok(resultado);
        }
        [HttpGet]
        [Route("Obtener_entrada_fecha/{fecha}")]

        public IActionResult getEntradas(DateTime fecha)
        {
            var resultado = _servicioEntradas.obtenerEntrada(fecha);
            
            return Ok(resultado);
            
            
        }
        [HttpGet]
        [Route("Obtener_entrada_fecha/{fecha}&&{filtro}")]

        public IActionResult getEntradas(DateTime fecha, string filtro)
        {
            var resultado = _servicioEntradas.obtenerEntrada(fecha, filtro);

            return Ok(resultado);


        }


        [HttpGet]
        [Route("Obtener_entrada_proveedor/{proveedor}")]

        public IActionResult getEntradasNombre(string proveedor)
        {
            var resultado = _servicioEntradas.obtenerEntrada(proveedor);

            return Ok(resultado);

        }

        [HttpGet]
        [Route("Obtener_entrada_proveedor/{proveedor}&&{filtro}")]

        public IActionResult getEntradas(string proveedor, string filtro)
        {
            var resultado = _servicioEntradas.obtenerEntrada(proveedor, filtro);

            return Ok(resultado);


        }

        [HttpGet]
        [Route("Obtener_entrada_producto/{producto}")]

        public IActionResult getEntradas(string producto)
        {
            var resultado = _servicioEntradas.obtenerEntradaProducto(producto);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_entrada_producto/{producto}&&{filtro}")]

        public IActionResult getEntradasProducto(string producto, string filtro)
        {
            var resultado = _servicioEntradas.obtenerEntradaProducto(producto, filtro);

            return Ok(resultado);


        }


        //Obtener facturaciones



        [HttpGet]
        [Route("Obtener_facturacion/")]

        public IActionResult getFacturacion()
        {
            var resultado = _servicioFacturacion.obtenerFacturacion();

            return Ok(resultado);
        }
        [HttpGet]
        [Route("Obtener_facturacion/{id}")]

        public IActionResult getFacturacion(int id)
        {
            var resultado = _servicioFacturacion.obtenerFacturacion(id);

            return Ok(resultado);
        }
        [HttpGet]
        [Route("Obtener_facturacion_fecha/{fecha}")]

        public IActionResult getFacturacion(DateTime fecha)
        {
            var resultado = _servicioFacturacion.obtenerFacturacion(fecha);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_facturacion_fecha/{fecha}&&{filtro}")]

        public IActionResult getFacturacion(DateTime fecha, string filtro)
        {
            var resultado = _servicioFacturacion.obtenerFacturacion(fecha, filtro);

            return Ok(resultado);


        }

        [HttpGet]
        [Route("Obtener_facturacion_cliente/{cliente}")]

        public IActionResult getFacturacionNombre(string cliente)
        {
            var resultado = _servicioFacturacion.obtenerFacturacion(cliente);

            return Ok(resultado);
        }

        [HttpGet]
        [Route("Obtener_facturacion_cliente/{cliente}&&{filtro}")]

        public IActionResult getFacturacion(string cliente, string filtro)
        {
            var resultado = _servicioFacturacion.obtenerFacturacion(cliente, filtro);

            return Ok(resultado);


        }
    }
}