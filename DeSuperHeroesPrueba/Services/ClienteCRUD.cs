using DeSuperHeroesPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class ClienteCRUD
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public ClienteCRUD(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }
        public List<Cliente> Obtener()
        {
            var resultado = _contexto.Cliente.ToList();
            return resultado;
        }
        public Boolean addCliente(Cliente _cliente)
        {
            try
            {
                _contexto.Cliente.Add(_cliente);
                _contexto.SaveChanges();
                return true;

            }
            catch (Exception error)
            {
                error.GetBaseException();
                return false;
            }
        }
        public Boolean editCliente(Cliente _cliente)
        {
            try
            {
                var editar = _contexto.Cliente.Where(cliente=>cliente.ID==_cliente.ID).FirstOrDefault();
                editar.nombre = _cliente.nombre;
                editar.RNC = _cliente.RNC;
                editar.telefono = _cliente.telefono;
                editar.email = _cliente.email;
                editar.categoria = _cliente.categoria;

                _contexto.SaveChanges();

                return true;
            
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public Boolean DeleteCliente(int idcliente)
        {
            try
            {
                var eliminar = _contexto.Cliente.Where(cliente => cliente.ID == idcliente).FirstOrDefault();
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
