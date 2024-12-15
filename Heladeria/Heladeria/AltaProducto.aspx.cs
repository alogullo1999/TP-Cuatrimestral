using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;


namespace Heladeria
    {
        public partial class AltaProducto : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategoria();
                CargarMarca();
                CargarProveedor();
                CargarImagen();
               

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
            {
                try
                {
 
                    string codigo = txtCodigo.Text;
                    string nombre = txtNombre.Text;
                    decimal precio = decimal.Parse(txtPrecio.Text);
                    string descripcion = txtDescripcion.Text;
                    int idMarca = int.Parse(ddlMarca.SelectedValue);
                    int idProveedor = int.Parse(ddlProveedor.SelectedValue);
                    int idCategoria = int.Parse(ddlCategoria.SelectedValue);
                int imagenUrl = int.Parse(ddlImagen.Text);

         
                    Producto producto = new Producto
                    {
                        Codigo = codigo,
                        Nombre = nombre,
                        Precio = precio,
                        Descripcion = descripcion,
                        marca = new Marca { IdMarca = idMarca },
                        proveedor = new Proveedor { IdProveedor = idProveedor },
                        imagenUrl = new Imagen { Id = imagenUrl }
                    };

            
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    productoNegocio.Agregar(producto);

                    Response.Redirect("GestionCliente.aspx");
                }
                catch (Exception ex)
                {

                    lblError.Text = "Ocurrió un error al guardar el producto: " + ex.Message;
                }
            }
        
        private void CargarMarca()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ddlMarca.DataSource = marcaNegocio.listarMarca();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
        }


        private void CargarProveedor()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            ddlProveedor.DataSource = proveedorNegocio.listarProveedor();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();
        }



        private void CargarCategoria()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ddlCategoria.DataSource = categoriaNegocio.listarCategoria();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
        }

        private void CargarImagen()
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            ddlImagen.DataSource = imagenNegocio.listarImagen();
            ddlImagen.DataTextField = "UrlImagen";
            ddlImagen.DataValueField = "Id";
            ddlImagen.DataBind();
        }






    }
}













