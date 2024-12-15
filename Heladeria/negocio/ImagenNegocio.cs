using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ImagenNegocio
    {


        public void Agregar(int id, string Url)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Imagenes (IdProducto, ImagenUrl) VALUES (@Id, @Url)");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Url", Url);
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



        public List<Imagen> listarImagen()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Imagen> listaImagen= new List<Imagen>();

            try
            {
                datos.setearConsulta("  SELECT Id, i.IdProducto, i.ImagenUrl, Nombre FROM Imagenes i  inner join Productos p on i.IdProducto = p.IdProducto;");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen
                    {
                        Id = (int)datos.Lector["Id"],
                        IdProducto = (int)datos.Lector["IdProducto"],
                        UrlImagen = (string)datos.Lector["ImagenUrl"],
                        NombreProducto = (string)datos.Lector["Nombre"],

                    };

                    listaImagen.Add(imagen);
                }

                return listaImagen;
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


        public void Modificar(Imagen modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Imagenes set ImagenUrl=@ImagenUrl where IdProducto=@IdProducto");
                datos.setearParametro("@ImagenUrl", modificar.UrlImagen);
                datos.setearParametro("@IdProducto", modificar.IdProducto);

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

        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Imagenes where Id=@id");
                datos.setearParametro("@id", Id);
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


        public bool ExisteImagenParaProducto(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Imagenes WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", idProducto);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector[0];
                    return cantidad > 0; 
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
