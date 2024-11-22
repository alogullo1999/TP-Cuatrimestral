using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DetalleVentaNegocio
    {
        public List<DetalleVenta> listar()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdVenta,FechaVenta,Estado,IdEmpleado,IdCliente,IdProducto,Cantidad,PrecioUnitario,TotalVenta FROM DetalleVentas");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta
                    {
                        IdVenta = (int)datos.Lector["IdVenta"],
                        FechaVenta = (DateTime)datos.Lector["Fecha venta"],
                        Estado = (string)datos.Lector["Estado"],
                        IdEmpleado = (int)datos.Lector["IdEmpleado"],
                        IdCliente = (int)datos.Lector["IdCliente"],
                        IdProducto = (int)datos.Lector["IdProducto"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (decimal)datos.Lector["Precio Unitario"],
                        TotalVenta = (decimal)datos.Lector["Total Venta"]
                    };
                    lista.Add(aux);
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarDetalleVenta(DetalleVenta detalleVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DetalleVentas(IdVenta,FechaVenta,Estado,IdEmpleado,IdCliente,IdProducto,Cantidad,PrecioUnitario,TotalVenta) VALUES (@IdVenta,@Fecha,@Estado,@IdEmpleado,@IdCliente,@IdProducto,@Cantidad,@Precio,@Total)");
                datos.setearParametro("@IdVenta", detalleVenta.IdVenta);
                datos.setearParametro("@Fecha", detalleVenta.FechaVenta);
                datos.setearParametro("@Estado", detalleVenta.Estado);
                datos.setearParametro("@IdEmpleado", detalleVenta.IdEmpleado);
                datos.setearParametro("@IdCliente", detalleVenta.IdCliente);
                datos.setearParametro("@IdProducto", detalleVenta.IdProducto);
                datos.setearParametro("@Cantidad", detalleVenta.Cantidad);
                datos.setearParametro("@Precio", detalleVenta.PrecioUnitario);
                datos.setearParametro("@Total", detalleVenta.TotalVenta);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarDetalleVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM DetalleVentas WHERE IdVenta=@idVenta");
                datos.setearParametro("@idVenta", id);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
