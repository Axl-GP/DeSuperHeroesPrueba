using DeSuperHeroesPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class ProductoCRUD
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public ProductoCRUD(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }
        public List<producto> Obtener()
        {
            var productos = _contexto.producto.Include(x=>x.Stock).ToList();
            return productos;
        }
        public Boolean AddProducto(producto _producto)
        {
            try
            {
                _contexto.producto.Add(_producto);
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
