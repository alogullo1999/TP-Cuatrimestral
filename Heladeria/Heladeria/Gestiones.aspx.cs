using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionProveedor.aspx");
        }

        protected void btnGestionarMarcas_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionMarcas.aspx");
        }

        protected void btnGestionarHelados_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionHelados.aspx");
        }

        protected void btnGestionarProductos_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionProductos.aspx");
        }

        protected void btnGestionarCompras_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionCompras.aspx");
        }

        protected void btnGestionarVentas_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionVentas.aspx");
        }

        protected void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de gestión de proveedores
            Response.Redirect("GestionCliente.aspx");
        }



    }
}