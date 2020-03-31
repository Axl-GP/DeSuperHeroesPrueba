using DeSuperHeroesPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class ClienteCRUD
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public ClienteCRUD(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }
        public List<Cliente> Obtener()
        {
            var resultado = _contexto.Cliente.ToList();
            return resultado;
        }
        public Boolean addCliente(Cliente _cliente)
        {
            try
            {
                _contexto.Cliente.Add(_cliente);
                _contexto.SaveChanges();
                return true;

            }
            catch (Exception error)
            {
                error.GetBaseException();
                return false;
            }
        }
    }
}
