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
        public List<producto_proveedor> Filtros(string nombre,string filtro)
        {
            var resultado = _contexto.producto_proveedor.Where(x => x.proveedor.nombre == nombre).ToList();

            if (filtro.Equals("conteo"))
            {
                
                return resultado;
            }

            return resultado;

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

        public decimal obtenerEntrada(DateTime fecha, string filtro)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.fechaImporte == fecha).ToList();

            switch (filtro) {
                case "promedio" :
                    return resultado.Average(x => x.producto.precio);

                case "conteo":
                    return resultado.Count();

                case "suma":
                    return resultado.Sum(x => x.producto.precio);
                    

                default:

                    return 0;
            }
          
           

        }

        

        public List<producto_proveedor> obtenerEntrada(string proveedor)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.proveedor.nombre == proveedor).ToList();

            return resultado;

        }

        public decimal obtenerEntrada(string proveedor, string filtro)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.proveedor.nombre == proveedor).ToList();

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


        public List<producto_proveedor> obtenerEntradaProducto(string producto)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.producto.nombre == producto).ToList();

            return resultado;

        }

        public decimal obtenerEntradaProducto(string producto, string filtro)
        {
            var resultado = _contexto.producto_proveedor.Include(x => x.proveedor).Include(y => y.producto).ThenInclude(y => y.Stock).Where(x => x.producto.nombre == producto).ToList();

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
