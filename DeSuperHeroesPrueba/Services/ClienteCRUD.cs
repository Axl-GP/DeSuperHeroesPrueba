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
        private readonly borrarRelaciones _clase;

        public ClienteCRUD(desuperheroesvipDBcontext context, borrarRelaciones clase)
        {
            _contexto = context;
            _clase = clase;
        }
        public List<Cliente> Obtener()
        {
            var resultado = _contexto.Cliente.ToList();
            return resultado;
        }
        public Cliente Obtener(int id)
        {
            var resultado = _contexto.Cliente.Where(x=>x.ID==id).FirstOrDefault();
            return resultado;
        }
        public List<Cliente> Obtener(string nombre)
        {
            var resultado = _contexto.Cliente.Where(x => x.nombre == nombre).ToList();
            return resultado;
        }
        public List<Cliente> ObtenerCategoria(string categoria)
        {
            var resultado = _contexto.Cliente.Where(x => x.categoria == categoria).ToList();

            //AQUI VA UN LINQ
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
                _clase.DeleteRelaciones(idcliente);
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

    public class borrarRelaciones
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public borrarRelaciones(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }

        public Boolean DeleteRelaciones(int id)
        {
            try
            {
                var facturas = _contexto.factura.Where(x => x.Clienteid == id).ToList();
                var compras = _contexto.producto_cliente.Where(x => x.clienteid == id).ToList();
                if (facturas!=null && compras!=null)
                {
                    foreach (Factura factura in facturas)
                    {
                        _contexto.factura.Remove(factura);
                        _contexto.SaveChanges();
                    }

                    foreach (producto_cliente compra in compras)
                    {
                        _contexto.Remove(compra);
                        _contexto.SaveChanges();
                    }

                   
                    return true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
