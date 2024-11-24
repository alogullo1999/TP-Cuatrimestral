using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;
using negocio;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT p.IdProducto,p.Nombre,p.Precio,p.Descripcion,p.Cantidad,m.IdMarca,pro.IdProveedor,h.IdHelado,i.ImagenUrl" +
                                    "FROM Productos p" +
                                    "INNER JOIN Marcas m ON p.IdMarca=m.IdMarca" +
                                    "INNER JOIN Proveedores pro ON p.IdProveedor=pro.IdProveedor" +
                                    "INNER JOIN Helados h ON p.IdHelado=h.IdHelado" +
                                    "INNER JOIN Imagenes i ON p.ImagenUrl=i.ImagenUrl"
                                    );

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto()
                    {
                        IdProducto = (int)datos.Lector["IdProducto"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Cantidad = (decimal)datos.Lector["Cantidad"]
                    };

                    aux.marca = new Marca
                    {
                        IdMarca = datos.Lector["IdMarca"] !=DBNull.Value ? (int)datos.Lector["IdMarca"] : 0
                    };

                    aux.proveedor = new Proveedor
                    {
                        IdProveedor = datos.Lector["IdProveedor"] != DBNull.Value ? (int)datos.Lector["IdProveedor"] : 0
                    };

                    aux.helado = new Helado
                    {
                        IdHelado = datos.Lector["IdHelado"] != DBNull.Value ? (int)datos.Lector["IdHelado"] : 0
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

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Productos(Codigo,Nombre,Precio,Descripcion,Cantidad,IdMarca,IdProveedor,IdHelado)" +
                                     "VALUES (@codigo,@nombre,@precio,@descripcion,@cantidad,@idMarca,@idProveedor,@idHelado");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@cantidad", nuevo.Cantidad);

                datos.setearParametro("@idMarca", nuevo.marca?.IdMarca ?? (object)DBNull.Value);
                datos.setearParametro("@idProveedor", nuevo.proveedor?.IdProveedor ?? (object)DBNull.Value);
                datos.setearParametro("@idHelado", nuevo.helado?.IdHelado ?? (object)DBNull.Value);

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

        public void Modificar(Producto prod)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Productos SET Codigo=@codigo,Nombre=@nombre,Precio=@Precio,Descripcion=@descripcion,Cantidad=@cantidad"+
                                     "WHERE IdProducto=@Id");

                datos.setearParametro("@codigo", prod.Codigo);
                datos.setearParametro("@nombre", prod.Nombre);
                datos.setearParametro("@precio", prod.Precio);
                datos.setearParametro("@descripcion", prod.Descripcion);
                datos.setearParametro("@cantidad", prod.Cantidad);
                datos.setearParametro("@Id", prod.IdProducto);

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

        public void Eliminar(int IdProducto)
        {
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Productos WHERE IdProducto=@idProducto");
                datos.setearParametro("@idProducto", IdProducto);

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


        public bool ExisteProducto(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Productos WHERE Codigo=@codigo");
                datos.setearParametro("@nombre", codigo);
                datos.EjecutarLectura();

                if(datos.Lector.Read() && (int)datos.Lector[0] > 0)
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

        
    }
}
