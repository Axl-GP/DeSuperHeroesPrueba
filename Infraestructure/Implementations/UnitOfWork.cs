using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            BillRepository = new BillRepository(_context);
            ClientRepository = new ClientRepository(_context);
            EntriesRepository = new EntriesRepository(_context);
            ProductRepository = new ProductRepository(_context);
            ProviderRepository = new ProviderRepository(_context);
            SellsRepository = new SellsRepository(_context);
            StockRepository = new StockRepository(_context);
            BillRepository = new BillRepository(_context);
        }

        public IBillRepository BillRepository { get; private set; }
        public IClientRepository ClientRepository { get; private set; }
        public IEntriesRepository EntriesRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IProviderRepository ProviderRepository { get; private set; }
        public ISellsRepository SellsRepository { get; private set; }
        public IStockRepository StockRepository { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
