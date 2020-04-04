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
        public proveedor Obtener(int id)
        {
            var proveedor = _contexto.proveedor.Where(x=>x.id==id).FirstOrDefault();
            return proveedor;
        }
        public proveedor Obtener(string nombre)
        {
            var proveedor = _contexto.proveedor.Where(x => x.nombre == nombre).FirstOrDefault();
            return proveedor;
        }
        public proveedor ObtenerEmail(string email)
        {
            var proveedor = _contexto.proveedor.Where(x => x.email == email).FirstOrDefault();
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
        public Boolean editProveedor(proveedor _proveedor)
        {
            try
            {
                var editar = _contexto.proveedor.Where(proveedor => proveedor.id == _proveedor.id).FirstOrDefault();
                editar.nombre = _proveedor.nombre;
                editar.RNC = _proveedor.RNC;
                editar.telefono = _proveedor.telefono;
                editar.email = _proveedor.email;
               

                _contexto.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Boolean DeleteProveedor(int idproveedor)
        {
            try
            {
                var eliminar = _contexto.proveedor.Where(proveedor => proveedor.id == idproveedor).FirstOrDefault();
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
