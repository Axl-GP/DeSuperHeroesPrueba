using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Implementations
{
    public class BillRepository:Repository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
