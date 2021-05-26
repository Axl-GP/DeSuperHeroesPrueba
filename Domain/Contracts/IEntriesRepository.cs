using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IEntriesRepository: IRepository<ProductProvider>
    {
        Task<IEnumerable<ProductProvider>> GetEntriesByDateAsync(DateTime date);
        Task<decimal> GetEntriesByDateAndFilterAsync(DateTime date, string filter);
        Task<IEnumerable<ProductProvider>> GetEntriesByProviderAsync(string provider);
        Task<decimal> GetEntriesByProviderAndFilterAsync(string provider, string filter);
        Task<IEnumerable<ProductProvider>> GetEntriesByProductAsync(string product);
        Task<decimal> GetEntriesByProductAndFilterAsync(string product, string filter);
    }
}
