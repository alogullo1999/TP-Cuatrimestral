using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdProveedor, Nombre, Email, Dni, Ciudad from Proveedores;");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor
                    {
                        IdProveedor = (int)datos.Lector["IdProveedor"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Email = (string)datos.Lector["Email"],
                        Dni = (string)datos.Lector["Dni"],
                        Ciudad = (string)datos.Lector["Ciudad"]
                    };

                    lista.Add(aux);
                }

                return lista;
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
                    return true; // Existe duplicado
                }
                return false; // No existe duplicado
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
                datos.setearConsulta("INSERT INTO Proveedores ( Nombre, Email, Dni, Ciudad) VALUES ( @Nombre, @Email, @Dni, @Ciudad)");

                datos.setearParametro("@Nombre", proveedor.Nombre);
                datos.setearParametro("@Email", proveedor.Email);
                datos.setearParametro("@Dni", proveedor.Dni);
                datos.setearParametro("@Ciudad", proveedor.Ciudad);
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
