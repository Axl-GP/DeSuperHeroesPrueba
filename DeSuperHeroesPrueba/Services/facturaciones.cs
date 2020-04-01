using DeSuperHeroesPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class facturaciones
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public facturaciones(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }


        public List<producto_cliente> obtenerFacturacion()
        {
            var resultado = _contexto.producto_cliente.Include(x => x.cliente).Include(y => y.producto).ThenInclude(y => y.Stock).ToList();

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
    }
}
