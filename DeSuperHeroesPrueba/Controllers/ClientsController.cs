using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Clients;
using Microsoft.AspNetCore.Mvc;

namespace DeSuperHeroesPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //apartado de metodos para el manejo de clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientOTO>>> GetClients() => Ok(_mapper
            .Map<IEnumerable<ClientOTO>>(await _unitOfWork.ClientRepository.GetAllAsync()));

        [HttpGet("{clientId}")]
        public async Task<ActionResult<ClientOTO>> GetClientById(int clientId)
        {
            return Ok(await _unitOfWork.ClientRepository.GetAsync(clientId));
        }
        
        [HttpPost]
        public async Task<ActionResult<ClientOTO>> AddClient([FromBody] ClientITO client)
        {
            if (client != null) { 
                try
                {
                    var dbClientMap = _mapper.Map<Client>(client);
                    await _unitOfWork.ClientRepository.AddAsync(dbClientMap);
                    await _unitOfWork.CompleteAsync();
                    var clientOTO = _mapper.Map<ClientOTO>(dbClientMap);
                    return new CreatedAtRouteResult( new { id = dbClientMap.Id }, clientOTO);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.HelpLink);
                    return BadRequest();
                }
                finally
                {
                    await _unitOfWork.DisposeAsync();
                }
            }
                return null;   
        }

        [HttpPut("{clientId}")]
        public async Task<ActionResult> EditClient(int clientId, [FromBody] ClientITO client)
        {
            var dbClient = await _unitOfWork.ClientRepository.GetAsync(clientId);
            if (dbClient != null && client!=null)
            {
                try
                {
                    var dbClientMap = _mapper.Map<Client>(client);
                    dbClient.Name = client.Name;
                    dbClient.Email = client.Email;
                    dbClient.RNC = client.RNC;
                    dbClient.PhoneNumber = client.PhoneNumber;
                    dbClient.Category = client.Category;
                    await _unitOfWork.CompleteAsync();
                    return new NoContentResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.HelpLink);
                    return BadRequest();
                }
                finally
                {
                    await _unitOfWork.DisposeAsync();
                }
            }
            return null;
        }

        [HttpDelete("{clientId}")]
        public async Task<ActionResult> DeleteClient(int clientId)
        {

            var dbClient = await _unitOfWork.ClientRepository.GetAsync(clientId);
            try
            {
                if (dbClient!=null)
                {
                    _unitOfWork.ClientRepository.Remove(dbClient);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }

        }
       
    }


}

