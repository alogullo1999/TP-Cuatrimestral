using System;
using System.Collections.Generic;
using System.Web.UI;
using negocio;
using dominio;
using Microsoft.AspNet.FriendlyUrls;

namespace Heladeria
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            gvProductos.DataSource = productoNegocio.listarProducto();
            gvProductos.DataBind();
        }


        protected void btnGestionarMarca_Click(object sender, EventArgs e)
        {

            Response.Redirect("GestionarMarcas.aspx");
        
        
        }


        protected void btnGestionarCategoria_Click(object sender, EventArgs e)
        {

            Response.Redirect("GestionarCategorias.aspx");


        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            Response.Redirect("AltaProducto.aspx");


        }


    }
}