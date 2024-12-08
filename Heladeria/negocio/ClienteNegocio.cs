using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listarCliente()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                datos.setearConsulta("SELECT IdCliente, Nombre, Apellido, Dni, Email, Ciudad FROM Clientes;");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = (int)datos.Lector["IdCliente"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Dni = (string)datos.Lector["Dni"],
                        Email = (string)datos.Lector["Email"],
                        Ciudad = (string)datos.Lector["Ciudad"]
                    };

                    listaClientes.Add(cliente);
                }

                return listaClientes;
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

        public bool ExisteCliente(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Clientes WHERE Nombre=@Nombre");
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

        public void AgregarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Clientes (Dni, Nombre, Apellido, Email, Ciudad)
                               VALUES (@Dni, @Nombre, @Apellido, @Email, @Ciudad)");

                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Ciudad", cliente.Ciudad);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar agregar un cliente: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"UPDATE Clientes 
                               
                               SET Nombre = @Nombre, 
                                   Apellido = @Apellido, 
                                   Dni = @Dni, 
                                   Email = @Email, 
                                   Ciudad = @Ciudad 
                               WHERE IdCliente = @IdCliente");

                datos.setearParametro("@IdCliente", cliente.IdCliente);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Ciudad", cliente.Ciudad);

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



        public void eliminarCliente(int idCliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Clientes WHERE IdCliente = @IdCliente");
                datos.setearParametro("@IdCliente", idCliente);
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





        public Cliente obtenerClientePorId(int idCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = null;

            try
            {
                datos.setearConsulta("SELECT IdCliente, Nombre, Apellido, Dni, Email, Ciudad FROM Clientes WHERE IdCliente = @IdCliente");
                datos.setearParametro("@IdCliente", idCliente);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = (int)datos.Lector["IdCliente"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Dni = (string)datos.Lector["Dni"],
                        Email = (string)datos.Lector["Email"],
                        Ciudad = (string)datos.Lector["Ciudad"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return cliente;
        }







    }
}
