using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure.DTO_s.Bill;
using Infraestructure.DTO_s.Bills;
using Infraestructure.DTO_s.Clients;
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
        private readonly IMapper _mapper;

        public BillsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //apartado de metodos para el manejo de Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillOTO>>> GetBills()=> Ok(_mapper.Map<IEnumerable<BillITO>>(await _unitOfWork.BillRepository.GetAllAsync()));

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientOTO>> GetBill(int id) => Ok(_mapper.Map<ClientOTO>(await _unitOfWork.ClientRepository.GetAsync(id)));

        [HttpPost]
        public async Task<ActionResult<BillOTO>> AddBill([FromBody] BillITO bill)
        {
            try
            {
                var dbBillMap = _mapper.Map<Bill>(bill);
                await _unitOfWork.BillRepository.AddAsync(dbBillMap);
                await _unitOfWork.CompleteAsync();
                var billOTO = _mapper.Map<BillOTO>(dbBillMap);
                return new CreatedAtRouteResult(new { id = dbBillMap.BillId }, billOTO);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> EditBill(int id,[FromBody] Bill bill)
        {

            var dbBill = await _unitOfWork.BillRepository.GetAsync(id);
            if (dbBill != null && bill != null)
            {
                try
                {
                    var dbBillMap = _mapper.Map<Bill>(bill);
                    dbBillMap.Quantity = bill.Quantity;
                    dbBillMap.Total = bill.Total;
                    dbBillMap.Date = bill.Date;
                    await _unitOfWork.CompleteAsync();
                    return NoContent();
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
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBill(int id)
        {

            var dbBill = await _unitOfWork.BillRepository.GetAsync(id);

            if (dbBill!=null)
            {
                try
                {
                    _unitOfWork.BillRepository.Remove(dbBill);
                    await _unitOfWork.CompleteAsync();
                    return NoContent();
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                finally
                {
                    await _unitOfWork.DisposeAsync();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
