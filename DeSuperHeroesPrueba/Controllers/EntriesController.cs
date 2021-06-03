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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryOTO>>> GetEntries() => Ok(_mapper
            .Map<IEnumerable<EntryOTO>>(await _unitOfWork.EntriesRepository.GetAllAsync()));

        [HttpGet("{id}")]
        public async Task<ActionResult<EntryOTO>> GetEntry(int id) 
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<EntryOTO>>(await _unitOfWork
                    .EntriesRepository.GetAsync(id));

                if (mappedResponse != null)
                    return Ok(mappedResponse);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("custom-search/{date}")]
        public async Task<ActionResult<IEnumerable<EntryOTO>>> GetEntriesByDate(DateTime date)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<EntryOTO>>(await _unitOfWork
                    .EntriesRepository.ToListAsync(x => x.ImportDate.CompareTo(date)==0));

                if (mappedResponse != null)
                    return Ok(mappedResponse);
                else
                    return NotFound();
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       
        [HttpGet("custom-search/{date}&&{filter}")]
        public async Task<ActionResult<decimal>> GetEntriesByDateAndFilter(DateTime date, string filter)=> await _unitOfWork
                    .EntriesRepository.GetEntriesByDateAndFilterAsync(date, filter);

        [HttpGet("custom-search/{providerName}")]
        public async Task<ActionResult<IEnumerable<EntryOTO>>> GetEntriesByProviderName(string providerName)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<EntryOTO>>(await _unitOfWork
                    .EntriesRepository.GetEntriesByProviderAsync(providerName));

                if (mappedResponse != null)
                    return Ok(mappedResponse);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("custom-search/{providerName}&&{filter}")]

        public async Task<ActionResult<decimal>> GetEntriesByProviderNameAndFilter(string providerName, string filter) => await _unitOfWork
                    .EntriesRepository.GetEntriesByProviderAndFilterAsync(providerName, filter);

        [HttpGet("custom-search/{productName}")]
        public async Task<ActionResult<IEnumerable<EntryOTO>>> GetEntriesByProductName(string productName)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<EntryOTO>>(await _unitOfWork
                    .EntriesRepository.GetEntriesByProductAsync(productName));

                if (mappedResponse != null)
                    return Ok(mappedResponse);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("custom-search/{productName}&&{filter}")]
        public async Task<ActionResult<decimal>> GetEntriesByProductNameAndFilter(string productName, string filter) => await _unitOfWork
                    .EntriesRepository.GetEntriesByProductAndFilterAsync(productName, filter);
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
