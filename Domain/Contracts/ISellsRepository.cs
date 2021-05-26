using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISellsRepository: IRepository<ProductClient>
    {
        Task<IEnumerable<ProductClient>> GetSellsByDateAsync(DateTime date);
        Task<decimal> GetSellsMetricsByDateAndFilterAsync(DateTime date, string filter);
        Task<IEnumerable<ProductClient>> GetSellsByClientAsync(string client);
        Task<decimal> GetSellsMetricsByClientAndFilterAsync(string client, string filter);
 
    }
}
