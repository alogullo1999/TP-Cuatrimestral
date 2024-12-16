using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProducto()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                p.IdProducto,
                p.Codigo,
                p.Nombre, 
                p.Precio, 
                p.Descripcion, 
                m.IdMarca,
                m.Nombre as NombreMarca,
                pr.IdProveedor,
                pr.Nombre as NombreProveedor,
                i.imagenUrl,
                c.IdCategoria,
                c.Nombre as NombreCategoria
            FROM Productos p
            INNER JOIN Marcas m ON p.IdMarca = m.IdMarca
            INNER JOIN Proveedores pr ON p.IdProveedor = pr.IdProveedor
            INNER JOIN Categoria c on p.Categoria = c.IdCategoria
            LEFT JOIN Imagenes i on i.IdProducto = p.IdProducto
        ");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto
                    {
                        IdProducto = datos.Lector["IdProducto"] != DBNull.Value ? (int)datos.Lector["IdProducto"] : 0,
                        Codigo = datos.Lector["Codigo"] != DBNull.Value ? (string)datos.Lector["Codigo"] : string.Empty,
                        Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : string.Empty,
                        Precio = datos.Lector["Precio"] != DBNull.Value ? (decimal)datos.Lector["Precio"] : 0,
                        Descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : string.Empty,


                        proveedor = new Proveedor
                        {
                            IdProveedor = datos.Lector["IdProveedor"] != DBNull.Value ? (int)datos.Lector["IdProveedor"] : 0,
                            Nombre = datos.Lector["NombreProveedor"] != DBNull.Value ? (string)datos.Lector["NombreProveedor"] : string.Empty
                        }
                    };

                    aux.categoria = new Categoria
                    {
                        IdCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0,
                        Nombre = datos.Lector["NombreCategoria"] != DBNull.Value ? (string)datos.Lector["NombreCategoria"] : string.Empty
                    };


                    aux.ImagenUrl = new Imagen
                    {
                        UrlImagen = datos.Lector["imagenUrl"] != DBNull.Value ? (string)datos.Lector["imagenUrl"] : null
                    };

                    aux.marca = new Marca
                    {
                        IdMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0,
                        Nombre = datos.Lector["NombreMarca"] != DBNull.Value ? (string)datos.Lector["NombreMarca"] : string.Empty
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

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    INSERT INTO Productos (Codigo, Nombre, Precio, Descripcion, IdMarca, IdProveedor) 
                    OUTPUT INSERTED.IdProducto
                    VALUES (@codigo, @nombre, @precio, @descripcion, @idMarca, @idProveedor)
                ");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.marca?.IdMarca ?? (object)DBNull.Value);
                datos.setearParametro("@idProveedor", nuevo.proveedor?.IdProveedor ?? (object)DBNull.Value);

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

        public void Modificar(Producto prod)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    UPDATE Productos 
                    SET Codigo = @codigo, 
                        Nombre = @nombre, 
                        Precio = @precio, 
                        Descripcion = @descripcion, 
                        IdMarca = @idMarca, 
                        IdProveedor = @idProveedor, 
                        imagenUrl = @imagenUrl
                    WHERE IdProducto = @idProducto
                ");

                datos.setearParametro("@codigo", prod.Codigo);
                datos.setearParametro("@nombre", prod.Nombre);
                datos.setearParametro("@precio", prod.Precio);
                datos.setearParametro("@descripcion", prod.Descripcion);
                datos.setearParametro("@idMarca", prod.marca?.IdMarca ?? (object)DBNull.Value);
                datos.setearParametro("@idProveedor", prod.proveedor?.IdProveedor ?? (object)DBNull.Value);
                datos.setearParametro("@idProducto", prod.IdProducto);

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

        public void Eliminar(int IdProducto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Productos WHERE IdProducto = @idProducto");
                datos.setearParametro("@idProducto", IdProducto);

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

        public bool ExisteProducto(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Productos WHERE Codigo = @codigo");
                datos.setearParametro("@codigo", codigo);
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
