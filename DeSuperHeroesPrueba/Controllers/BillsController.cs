using Domain.Contracts;
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
    public class BillsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public BillsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //apartado de metodos para el manejo de clientes
        [HttpGet]
        [Route("Obtener_clientes")]
        public IActionResult getClientes()
        {
            return Ok(_unitOfWork.ClientRepository.GetAllAsync());
        }

        [HttpPost]
        [Route("agregar_clientes")]
        public IActionResult AddCliente([FromBody] Client _cliente)
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
        public IActionResult editCliente([FromBody] Cliente _cliente)
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
    }
}
