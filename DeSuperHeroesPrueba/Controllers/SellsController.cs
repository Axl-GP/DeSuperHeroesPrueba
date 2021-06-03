using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Sells;
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
    public class SellsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SellsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("custom-search/{date}")]
        public async Task<ActionResult<IEnumerable<SellOTO>>> GetSellsByDate(DateTime date)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<SellOTO>>(await _unitOfWork
                    .SellsRepository.ToListAsync(x => x.BillDate.CompareTo(date) == 0));

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
        [HttpGet("custom-search/{date}&&{filter}")]
        public async Task<ActionResult<decimal>> GetSellsByDateAndFilter(DateTime date, string filter) => await _unitOfWork
                    .SellsRepository.GetSellsMetricsByDateAndFilterAsync(date, filter);

        [HttpGet("custom-search/{clientName}")]
        public async Task<ActionResult<IEnumerable<SellOTO>>> GetSellsByClientName(string clientName)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<SellOTO>>(await _unitOfWork
                    .SellsRepository.GetSellsByClientAsync(clientName));

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

        [HttpGet("custom-search/{clientName}&&{filter}")]

        public async Task<ActionResult<decimal>> GetSellsByClientNameAndFilter(string clientName, string filter) => await _unitOfWork
                    .SellsRepository.GetSellsMetricsByClientAndFilterAsync(clientName, filter);


        [HttpPost]
        public async Task<ActionResult<SellOTO>> AddSell([FromBody] SellITO model)
        {
            try
            {
                var dbSellMap = _mapper.Map<ProductClient>(model);
                await _unitOfWork.SellsRepository.AddAsync(dbSellMap);
                await _unitOfWork.CompleteAsync();
                var sellOTO = _mapper.Map<SellOTO>(dbSellMap);
                return new CreatedAtRouteResult(new { id = dbSellMap.ProductClientId }, sellOTO);
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
