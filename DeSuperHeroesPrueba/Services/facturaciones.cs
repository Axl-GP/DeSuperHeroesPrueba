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

        public Boolean Addfactura(producto_cliente compra)
        {
            try
            {
                _contexto.producto_cliente.Add(compra);
                _contexto.SaveChanges();
                return true;

            }
            catch (Exception error)
            {
                error.GetBaseException();
                return false;
            }
        }

        public List<Factura> obtenerFacturacion()
        {
            var resultado = _contexto.factura.Include(x => x.cliente).ToList();

            return resultado;

        }
        public Factura obtenerFacturacion(int id)
        {
            var resultado = _contexto.factura.Include(x => x.cliente).Where(x=>x.Facturaid==id).FirstOrDefault();

            return resultado;

        }

        public List<producto_cliente> obtenerFacturacion(DateTime fecha)
        {
            var resultado = _contexto.producto_cliente.Include(x => x.cliente).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.fechaFactura == fecha).ToList();

            return resultado;

        }
        public decimal obtenerFacturacion(DateTime fecha, string filtro)
        {
            var resultado = _contexto.producto_cliente.Include(x => x.cliente).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.fechaFactura == fecha).ToList();

            switch (filtro)
            {
                case "promedio":
                    return resultado.Average(x => x.producto.precio);

                case "conteo":
                    return resultado.Count();

                case "suma":
                    return resultado.Sum(x => x.producto.precio);


                default:

                    return 0;
            }



        }

        public List<producto_cliente> obtenerFacturacion(string cliente)
        {
            var resultado = _contexto.producto_cliente.Include(x => x.cliente).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.cliente.nombre == cliente).ToList();

            return resultado;

        }

        public decimal obtenerFacturacion(string cliente, string filtro)
        {
            var resultado = _contexto.producto_cliente.Include(x => x.cliente).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.cliente.nombre == cliente).ToList();

            switch (filtro)
            {
                case "promedio":
                    return resultado.Average(x => x.producto.precio);

                case "conteo":
                    return resultado.Count();

                case "suma":
                    return resultado.Sum(x => x.producto.precio);


                default:

                    return 0;
            }



        }
    }
}
