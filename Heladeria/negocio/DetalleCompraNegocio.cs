using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DetalleCompraNegocio
    {

        public void AgregarDetalleCompra(DetalleCompra detallleCompra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO DetalleCompras(FechaCompra,IdCompra,IdProveedor,IdProducto,Cantidad,PrecioUnitario,TotalCompra) VALUES (@Fecha,@IdCompra,@IdProveedor,@IdProducto,@Cantidad,@Precio,@Total)");
                datos.setearParametro("@Fecha", detallleCompra.FechaCompra);
                datos.setearParametro("@IdCompra", detallleCompra.IdCompra);
                datos.setearParametro("@IdProveedor", detallleCompra.IdProveedor);
                datos.setearParametro("@IdProducto", detallleCompra.IdProducto);
                datos.setearParametro("@Cantidad", detallleCompra.Cantidad);
                datos.setearParametro("@Precio", detallleCompra.PrecioUnitario);
                datos.setearParametro("@Total", detallleCompra.TotalCompra);

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

        public void EliminarDetalleCompra(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM DetalleCompras WHERE IdCompra=@idCompra");
                datos.setearParametro("@idCompra", id);

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
