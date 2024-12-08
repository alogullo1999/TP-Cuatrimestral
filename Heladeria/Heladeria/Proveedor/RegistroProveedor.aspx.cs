using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class RegistroProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Complete todos los campos antes de guardar');", true);
                return;
            }


            Proveedor proveedor = new Proveedor
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Dni = txtDNI.Text,
                Ciudad = txtCiudad.Text,
                Telefono = txtTelefono.Text
            };


            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            try
            {
               proveedorNegocio.AgregarProveedor(proveedor);

                Response.Redirect("GestionProveedor.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al registrar cliente: {ex.Message}');", true);
            }
        }

    }
}



