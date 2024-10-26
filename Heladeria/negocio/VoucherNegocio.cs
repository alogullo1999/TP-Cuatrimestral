using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VoucherNegocio
    {
        public Voucher obtenerVoucher(string CV)
        {
            AccesoDatos datos= new AccesoDatos();
            Voucher voucher = new Voucher();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher,IdCliente,FechaCanje,IdArticulo FROM Voucher");
                datos.setearParametro("@Codigo", "%" + CV + "%");
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher.IdCliente = (int)datos.Lector["IdCliente"];
                    voucher.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    voucher.IdProducto = (int)datos.Lector["IdProducto"];
                }
                return voucher;
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
