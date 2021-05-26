using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        IBillRepository BillRepository { get; }
        IClientRepository ClientRepository { get; }
        IEntriesRepository EntriesRepository { get;  }
        IProductRepository ProductRepository { get;  }
        IProviderRepository ProviderRepository { get; }
        ISellsRepository SellsRepository { get;}
        IStockRepository StockRepository { get;  }
        Task<int> CompleteAsync();
        Task DisposeAsync();

    }
}
