using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Providers;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProvidersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderOTO>>> GetProviders() => Ok(_mapper
            .Map<IEnumerable<ProviderOTO>>(await _unitOfWork.ProviderRepository.GetAllAsync()));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderOTO>> GetProviderById(int id) => Ok(_mapper
            .Map<IEnumerable<ProviderOTO>>(await _unitOfWork.ProviderRepository.GetAsync(id)));

        [HttpGet("custom-search/{name}")]
        public async Task<ActionResult<IEnumerable<ProviderOTO>>> GetProvidersByName(string name) => Ok(_mapper
            .Map<IEnumerable<ProviderOTO>>(await _unitOfWork.ProviderRepository.ToListAsync(x => x.Name == name)));
        
        [HttpGet("custom-search/email/{email}")]
        public async Task<ActionResult<IEnumerable<ProviderOTO>>> GetProvidersByEmail(string email) => Ok(_mapper
            .Map<IEnumerable<ProviderOTO>>(await _unitOfWork.ProviderRepository.ToListAsync(x => x.Email == email)));

        [HttpPost]
        public async Task<ActionResult<ProviderOTO>> AddProvider([FromBody] ProviderITO model)
        {
            try
            {
                var dbModelMap = _mapper.Map<Provider>(model);
                await _unitOfWork.ProviderRepository.AddAsync(dbModelMap);
                await _unitOfWork.CompleteAsync();
                var outModelMap = _mapper.Map<ProviderOTO>(dbModelMap);
                return new CreatedAtRouteResult(new { id = dbModelMap.Id }, outModelMap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditProvider(int id, [FromBody] ProviderITO model)
        {
            try
            {
                var dbIdItem = await _unitOfWork.ProviderRepository.GetAsync(id);
                if (dbIdItem!=null)
                {
                    var dbModelMap = _mapper.Map<Provider>(model);
                    dbIdItem.Name = dbModelMap.Name;
                    dbIdItem.RNC = dbModelMap.RNC;
                    dbIdItem.Email = dbModelMap.Email;
                    dbIdItem.PhoneNumber = dbModelMap.PhoneNumber;
                    await _unitOfWork.CompleteAsync();
                    return NoContent();
                }
                else
                {
                    return NotFound();
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
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProvider(int id)
        {

            try
            {
                var dbIdItem = await _unitOfWork.ProviderRepository.GetAsync(id);
                if (dbIdItem != null)
                {
                    _unitOfWork.ProviderRepository.Remove(dbIdItem);
                    return NoContent();
                }
                else
                {
                    return NotFound();
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
