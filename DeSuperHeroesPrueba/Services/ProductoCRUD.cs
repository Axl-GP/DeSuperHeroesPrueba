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
        private readonly borrarRelaciones _borrado;

        public ProductoCRUD(desuperheroesvipDBcontext context, borrarRelaciones borrado)
        {
            _contexto = context;
            _borrado = borrado;
        }
        public List<producto> Obtener()
        {
            var productos = _contexto.producto.Include(x=>x.Stock).ToList();
            return productos;
        }
        public producto ObtenerID(int id)
        {
            try
            {
                var productos = _contexto.producto.Include(x => x.Stock).Where(x => x.id == id).FirstOrDefault();

                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public producto ObtenerNombre(string nombre)
            {
                try
                {
                    var productos = _contexto.producto.Include(x => x.Stock).Where(x => x.nombre == nombre).FirstOrDefault();

                    return productos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return null;
                }

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

        public Boolean editProducto(producto _producto)
        {
            try
            {
                var editar = _contexto.producto.Where(producto => producto.id == _producto.id).FirstOrDefault();
                editar.nombre = _producto.nombre;
                editar.precio = _producto.precio;
                editar.Stockid = _producto.Stockid;
                


                _contexto.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public Boolean Deleteproducto(int idproducto)
        {
            try
            {
                _borrado.borrarProducto(idproducto);
                var eliminar = _contexto.producto.Where(producto => producto.id == idproducto).FirstOrDefault();
                _contexto.Remove(eliminar);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
