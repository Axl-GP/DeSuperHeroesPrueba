using Infraestructure;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infraestructure.Implementations
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<bool> DeleteProductRelationsAsync(int productId)
        {
            try
            {
                var entries = await _context.Entries.Include(x => x.Product).Include(x => x.Provider)
                    .Where(x => x.ProductId == productId).ToListAsync();
                var selected = entries.Find(x => x.ProductId == productId);
                int total = (entries.Select(x => x.Quantity).Sum());
                var sells = _context.Sells.Where(x => x.ProductId == productId).ToList();

                var stock = await _context.Stocks.Where(x => x.Id == selected.Product.StockId).FirstOrDefaultAsync();
                //.Equals(_contexto.producto_proveedor.Where(x => x.productoid == id))
                if (entries != null && sells != null && stock != null)
                {
                    foreach (var item in entries)
                    {
                        stock.Quantity -= total;
                        stock.LastDate = DateTime.Now;
                        _context.Update(stock);
                        _context.Entries.Remove(item);
                        _context.SaveChanges();
                    }

                    foreach (var sell in sells)
                    {
                        _context.Remove(sell);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

