using DeSuperHeroesPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Services
{
    public class borrarRelaciones
    {
        private readonly desuperheroesvipDBcontext _contexto;

        public borrarRelaciones(desuperheroesvipDBcontext context)
        {
            _contexto = context;
        }

        //En este metodo se borran los registros de las tablas dependientes de cliente
        public Boolean borrarCliente(int id)
        {
            try
            {
                var facturas = _contexto.factura.Where(x => x.Clienteid == id).ToList();
                var compras = _contexto.producto_cliente.Where(x => x.clienteid == id).ToList();
                if (facturas != null && compras != null)
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

        //En este metodo borramos los registros dependientes de producto
        public Boolean borrarProducto(int id)
        {
            try
            {
                var entradas = _contexto.producto_proveedor.Where(x => x.productoid == id).ToList();
                var total = entradas.Select(x => x.cantidad).Sum();
                var compras = _contexto.producto_cliente.Where(x => x.productoid == id).ToList();
                var stock = _contexto.stock.Where(x => x.id.Equals(_contexto.producto_proveedor.Where(x => x.productoid == id)));
                if (entradas != null && compras != null && stock!=null)
                {
                    foreach (producto_proveedor entrada in entradas)
                    {
                        _contexto.stock.Sum(x=>x.existencia-total);
                        _contexto.producto_proveedor.Remove(entrada);
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
