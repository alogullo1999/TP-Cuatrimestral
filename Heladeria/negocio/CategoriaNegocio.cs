using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {


    public List<Categoria> listarCategoria()
    {
        List<Categoria> lista = new List<Categoria>();
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setearConsulta("SELECT IdCategoria,Nombre FROM Categoria");
            datos.EjecutarLectura();

            while (datos.Lector.Read())
            {
                Categoria aux = new Categoria();
                aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                aux.Nombre = (string)datos.Lector["Nombre"];

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

    public void Agregar(Categoria nuevo)
    {
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setearConsulta("INSERT INTO Categoria (Nombre) VALUES (@Nombre)");
            datos.setearParametro("@Nombre", nuevo.Nombre);

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

    public void Modificar(Categoria modificar)
    {
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setearConsulta("UPDATE Categoria set Nombre=@nombre where IdCategoria=@id");
            datos.setearParametro("@nombre", modificar.Nombre);
            datos.setearParametro("@id", modificar.IdCategoria);

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

    public void Eliminar(int IdCategoria)
    {
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setearConsulta("DELETE FROM Categoria where IdCategoria=@id");
            datos.setearParametro("@id", IdCategoria);
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



