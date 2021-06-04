using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Infraestructure.DTO_s.Stock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeSuperHeroesPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public StockController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockOTO>>> GetStock() => Ok(_mapper
            .Map<IEnumerable<StockOTO>>(await _unitOfWork.StockRepository.GetAllAsync()));

    }
}