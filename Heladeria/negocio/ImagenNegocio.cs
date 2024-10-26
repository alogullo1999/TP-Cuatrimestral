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
        private List<String> ListaImagen;

        public void Agregar(int id,string Url)
        {
            AccesoDatos datos= new AccesoDatos();
            Imagen img = new Imagen();
            
            try
            {
                datos.setearConsulta("INSERT INTO imagenes (IdProducto,ImagenUrl) VALUES (@Id,@Url)");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Url", Url);
                datos.ejecutarAccion();

                foreach(string s in ListaImagen)
                {
                    datos.setearConsulta("INSERT INTO imagenes (IdProducto,ImagenUrl) VALUES (@Id,@Url)");
                    datos.setearParametro("@Id", id);
                    datos.setearParametro("@Url", Url);
                    datos.ejecutarAccion();
                }
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

        public void ObtenerLista(List<String> urlImagenes)
        {
            ListaImagen = urlImagenes;
        }


    }
}
