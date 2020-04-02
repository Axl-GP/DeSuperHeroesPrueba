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

        public producto_proveedor obtenerEntrada(int id)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x=>x.producto_proveedorid==id).FirstOrDefault();

            return resultado;

        }
        public List<producto_proveedor> obtenerEntrada(DateTime fecha)
        {
                var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.fechaImporte == fecha).ToList();

                    return resultado;
         
        }
        public List<producto_proveedor> obtenerEntrada(string proveedor)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.proveedor.nombre == proveedor).ToList();

            return resultado;

        }
        public List<producto_proveedor> obtenerEntradaProducto(string nombre)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.producto.nombre == nombre).ToList();

            return resultado;

        }

    }
}
