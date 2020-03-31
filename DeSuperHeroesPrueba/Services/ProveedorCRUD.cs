using DeSuperHeroesPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class ProveedorCRUD
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public ProveedorCRUD(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }
        public List<proveedor> Obtener()
        {
            var proveedor = _contexto.proveedor.ToList();
            return proveedor;
        }
        public Boolean AddProveedor(proveedor _proveedor)
        {
            try
            {
                _contexto.proveedor.Add(_proveedor);
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
