using Infraestructure;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Implementations
{
    public class StockRepository:Repository<Stock>, IStockRepository
    {


        public StockRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
