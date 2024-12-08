using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Data.SqlClient;

namespace Heladeria
{
    public partial class GestionCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaCliente = clienteNegocio.listarCliente();
            gvClientes.DataSource = listaCliente;
            gvClientes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegistroClientes.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese un ID de cliente.');", true);
                return;
            }

            int idCliente;
            if (!int.TryParse(txtID.Text, out idCliente))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El ID debe ser un número válido.');", true);
                return;
            }

            // Redirigir al formulario de modificación con el ID como parámetro
            Response.Redirect($"ModificarCliente.aspx?idCliente={idCliente}");
        }







        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text)) 
            {
                int idCliente;

                if (int.TryParse(txtID.Text, out idCliente))
                {
                    ClienteNegocio clienteNegocio = new ClienteNegocio();

                    clienteNegocio.eliminarCliente(idCliente);

                    CargarClientes();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese un ID válido.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese un ID.');", true);
            }
        }

    }
}
