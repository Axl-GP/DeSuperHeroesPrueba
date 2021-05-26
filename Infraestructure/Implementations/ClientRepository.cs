using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Implementations
{
    public class ClientRepository:Repository<Client>, IClientRepository
    {

        public ClientRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
