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
        public Boolean Deleteproducto(int idproducto)
        {
            try
            {
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
