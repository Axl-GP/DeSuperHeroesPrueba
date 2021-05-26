using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Implementations
{
    public class ProviderRepository:Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
