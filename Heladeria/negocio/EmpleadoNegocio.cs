using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdEmpleado,Usuario,Nombre,Apellido,Dni FROM Empleados");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado
                    {
                        IdEmpleado = (int)datos.Lector["IdEmpleado"],
                        Usuario = (string)datos.Lector["Usuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Dni = (string)datos.Lector["Dni"]
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
        
        
        public void AgregarEmpleado(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Empleados(Usuario,Nombre,Apellido,Dni) VALUES (@Usuario,@Nombre,@Apellido,@Dni)");

                datos.setearParametro("@Usuario", empleado.Usuario);
                datos.setearParametro("@Nombre", empleado.Nombre);
                datos.setearParametro("@Apellido", empleado.Apellido);
                datos.setearParametro("@Dni", empleado.Dni);

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
        
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Empleados WHERE IdEmpleado=@id");
                datos.setearParametro("@id", id);
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

        public bool ExisteEmpleado(string Dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Empleados WHERE Dni=@dni");
                datos.setearParametro("@dni", Dni);
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
    }
}
