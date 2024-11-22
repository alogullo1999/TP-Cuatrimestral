using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class HeladoNegocio
    {
        public List<Helado> listar()
        {
            List<Helado> lista= new List<Helado>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdHelado,NombreHelado FROM Helados;");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Helado aux = new Helado
                    {
                        IdHelado = (int)datos.Lector["IdHelado"],
                        NombreHelado = (string)datos.Lector["NombreHelado"]
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

        public bool ExisteHelado(string Nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try 
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Helados WHERE NombreHelado=@Nombre");
                datos.setearParametro("@Nombre", Nombre);
                datos.EjecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0]>0)
                {
                    return true;
                }
                return false;
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

        public void AgregarHelado(Helado helado)
        {
            AccesoDatos datos=new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Helados(NombreHelado) VALUES (@Nombre)");
                datos.setearParametro("@Nombre", helado.NombreHelado);

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
