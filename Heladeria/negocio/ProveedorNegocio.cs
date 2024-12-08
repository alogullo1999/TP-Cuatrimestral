using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listarProveedor()
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdProveedor, Nombre, Email, Dni, Ciudad, Telefono from Proveedores;");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor
                    {
                        IdProveedor = (int)datos.Lector["IdProveedor"],
                        Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : null,
                        Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : null,
                        Dni = datos.Lector["Dni"] != DBNull.Value ? (string)datos.Lector["Dni"] : null,
                        Ciudad = datos.Lector["Ciudad"] != DBNull.Value ? (string)datos.Lector["Ciudad"] : null,
                        Telefono = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : null
                    };

                    listaProveedor.Add(aux);
                }

                return listaProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public bool ExisteProveedor(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Proveedores WHERE Nombre = @Nombre");
                datos.setearParametro("@Nombre", nombre);
                datos.EjecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0] > 0)
                {
                    return true; 
                }
                return false; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Proveedores ( Nombre, Email, Dni, Ciudad, Telefono) VALUES ( @Nombre, @Email, @Dni, @Ciudad, @Telefono)");

                datos.setearParametro("@Nombre", proveedor.Nombre);
                datos.setearParametro("@Email", proveedor.Email);
                datos.setearParametro("@Dni", proveedor.Dni);
                datos.setearParametro("@Ciudad", proveedor.Ciudad);
                datos.setearParametro("@Telefono", proveedor.Telefono);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
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
