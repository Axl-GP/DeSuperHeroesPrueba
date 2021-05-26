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
    public class EntriesRepository : Repository<ProductProvider>, IEntriesRepository
    {
        private readonly ApplicationDbContext _context;

        public EntriesRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<ProductProvider>> GetEntriesByDateAsync(DateTime date)
        {
            return await _context.Entries.Include(x => x.Provider).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.ImportDate == date).ToListAsync();
        }

        public async Task<decimal> GetEntriesByDateAndFilterAsync(DateTime date, string filter)
        {
            var response = await _context.Entries.Include(x => x.Provider).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.ImportDate == date).ToListAsync();

            switch (filter)
            {
                case "promedio":
                    return (decimal)response.Average(x => x.Quantity);

                case "conteo":
                    return response.Count();

                case "suma":
                    decimal quantity = response.Sum(x => x.Quantity);

                    decimal total = quantity * response.Sum(x => x.Product.Price);
                    return quantity;

                default:

                    return 0;
            }
        }

        public async Task<IEnumerable<ProductProvider>> GetEntriesByProductAsync(string product)
        {
                return await _context.Entries.Include(x => x.Provider).Include(y => y.Product).
                    ThenInclude(y => y.Stock).Where(x => x.Product.Name == product).ToListAsync();
        }

        public async Task<decimal> GetEntriesByProductAndFilterAsync(string product, string filter)
        {
            var response = await _context.Entries.Include(x => x.Provider).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.Product.Name == product).ToListAsync();

            switch (filter)
            {
                case "promedio":
                    return (decimal)response.Average(x => x.Quantity);

                case "conteo":
                    return response.Count();

                case "suma":
                    decimal quantity = response.Sum(x => x.Quantity);

                    decimal total = quantity * response.Sum(x => x.Product.Price);
                    return quantity;


                default:

                    return 0;
            }
        }

        public async Task<IEnumerable<ProductProvider>> GetEntriesByProviderAsync(string provider)
        {
            return await _context.Entries.Include(x => x.Provider).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.Provider.Name == provider).ToListAsync();
 
        }

        public async Task<decimal> GetEntriesByProviderAndFilterAsync(string provider, string filter)
        {
            var response = await _context.Entries.Include(x => x.Provider).Include(y => y.Product)
                .ThenInclude(y => y.Stock).Where(x => x.Provider.Name == provider).ToListAsync();

            switch (filter)
            {
                case "promedio":
                    return (decimal)response.Average(x => x.Quantity);

                case "conteo":
                    return response.Count();

                case "suma":
                    decimal quantity = response.Sum(x => x.Quantity);

                    decimal total = quantity * response.Sum(x => x.Product.Price);
                    return quantity;

                default:

                    return 0;
            }


        }
    }
}
