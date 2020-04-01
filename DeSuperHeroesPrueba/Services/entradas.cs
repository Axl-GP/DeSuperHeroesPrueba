using DeSuperHeroesPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class entradas
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public entradas(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }

        public List<producto_proveedor> obtenerEntrada()
        {
            var resultado = _contexto.producto_proveedor.Include(x=>x.proveedor).Include(y=>y.producto).ThenInclude(y=>y.Stock).ToList();

            return resultado;

        }

        public List<producto_proveedor> obtenerEntrada(DateTime fecha)
        {
                var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.fechaImporte == fecha).ToList();

                    return resultado;
         
        }
        public List<producto_proveedor> obtenerEntrada(string producto)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.producto.nombre == producto).ToList();

            return resultado;

        }

    }
}
