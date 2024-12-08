using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Heladeria
{
    public partial class GestionProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            List<dominio.Proveedor> listaProveedores = proveedorNegocio.listarProveedor(); 
            gvProveedores.DataSource = listaProveedores;
            gvProveedores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegistroProveedor.aspx");

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegistroProveedor.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegistroProveedor.aspx");

        }


    }

}