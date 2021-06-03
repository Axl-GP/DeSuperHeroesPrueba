using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Products;
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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOTO>>> GetProducts() => Ok(_mapper
            .Map<IEnumerable<ProductOTO>>(await _unitOfWork.ProductRepository.GetAllAsync()));

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductOTO>> GetProduct(int productId) => Ok( _mapper
            .Map<ProductOTO>(await _unitOfWork.ProductRepository.GetAsync(productId)));

        [HttpGet("{stock/stockId}")]
        public async Task<ActionResult<ProductOTO>> GetProductStock(int stockId) => Ok(_mapper
            .Map<ProductOTO>(await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x=>x.StockId == stockId)));


        [HttpGet("custom-search/{name}")]
        public async Task<ActionResult<ProductOTO>> GetProductsByName(string name)
        {
            try
            {
                var mappedResponse = _mapper.Map<IEnumerable<ProductOTO>>(await _unitOfWork
                    .ProductRepository.ToListAsync(x => x.Name == name));

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

        [HttpPost]
        public async Task<ActionResult<ProductOTO>> AddProductos([FromBody] ProductITO product)
        {
            if (product != null)
            {
                try
                {
                    var dbProductMap = _mapper.Map<Product>(product);
                    await _unitOfWork.ProductRepository.AddAsync(dbProductMap);
                    await _unitOfWork.CompleteAsync();
                    var productOTO = _mapper.Map<ProductOTO>(dbProductMap);
                    return new CreatedAtRouteResult( new { id = dbProductMap.Id }, productOTO);
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

        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductOTO>> EditProduct(int productId, [FromBody] ProductITO product)
        {

            var dbProduct = await _unitOfWork.ProductRepository.GetAsync(productId);
            if (dbProduct != null && product != null)
            {
                try
                {
                    var dbProductMap = _mapper.Map<Product>(product);
                    dbProductMap.Name = product.Name;
                    dbProductMap.Price = product.Price;
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

        [HttpDelete("{productId}")]
        public async Task<ActionResult<ProductOTO>> DeleteProduct(int productId)
        {
            var dbProduct = await _unitOfWork.ProductRepository.GetAsync(productId);
            try
            {
                if (dbProduct != null)
                {
                    _unitOfWork.ProductRepository.Remove(dbProduct);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
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
    }
}
