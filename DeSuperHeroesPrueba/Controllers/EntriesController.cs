using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Entries;
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
    public class EntriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EntriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<EntryOTO>> AddEntry([FromBody] EntryITO entry)
        {
            try
            {
                var dbEntryMap = _mapper.Map<ProductProvider>(entry);
                await _unitOfWork.EntriesRepository.AddAsync(dbEntryMap);
                await _unitOfWork.CompleteAsync();
                var entryOTO = _mapper.Map<EntryOTO>(dbEntryMap);
                return new CreatedAtRouteResult(new { id = dbEntryMap.ProductProviderId }, entryOTO);
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
    }
}
