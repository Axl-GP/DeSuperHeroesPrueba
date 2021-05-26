using Infraestructure;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementations
{
    public class SellsRepository : Repository<ProductClient>, ISellsRepository
    {
        private readonly ApplicationDbContext _context;

        public SellsRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductClient>> GetSellsByDateAsync(DateTime date)
        {
            return await _context.Sells.Include(x => x.Client).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.BillDate == date).ToListAsync();
        }
        public async Task<decimal> GetSellsMetricsByDateAndFilterAsync(DateTime date, string filter)
        {
            var response = await _context.Sells.Include(x => x.Client).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.BillDate == date).ToListAsync();
            var bill = _context.Bills.Include(x => x.Client).Where(x => x.Date == date);

            switch (filter)
            {
                case "promedio":
                    return (decimal)bill.Average(x => x.Quantity);

                case "conteo":
                    return bill.Count();

                case "suma":
                    return bill.Sum(x => x.Total);


                case "maximo":
                    return bill.Max(x => x.Total);

                case "minimo":
                    return bill.Min(x => x.Total);


                default:

                    return 0;
            }
        }
        public async Task<IEnumerable<ProductClient>> GetSellsByClientAsync(string client)
        {
             return await _context.Sells.Include(x => x.Client).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.Client.Name == client).ToListAsync();
        }
        public async Task<decimal> GetSellsMetricsByClientAndFilterAsync(string client, string filter)
        {
            var response = await _context.Sells.Include(x => x.Client).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.Client.Name == client).FirstOrDefaultAsync();

            var bill = await _context.Bills.Include(x => x.Client).Where(x => x.Client.Name == client).ToListAsync();

            switch (filter)
            {
                case "promedio":
                    return (decimal)bill.Average(x => x.Quantity);

                case "conteo":
                    return bill.Count();

                case "suma":
                    return bill.Sum(x => x.Total);

                case "maximo":
                    return bill.Max(x => x.Total);

                case "minimo":
                    return bill.Min(x => x.Total);

                default:

                    return 0;
            }
        }




    }
}
