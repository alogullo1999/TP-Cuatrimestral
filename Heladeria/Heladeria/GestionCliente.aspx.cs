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
            // Redirige a una página o muestra un formulario para agregar un cliente.
            Response.Redirect("RegistroClientes.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Valida si hay un cliente seleccionado.
            if (gvClientes.SelectedRow != null)
            {
                int idCliente = Convert.ToInt32(gvClientes.SelectedRow.Cells[0].Text);
                // Redirige a una página de modificación con el ID del cliente como parámetro.
                Response.Redirect($"ModificarCliente.aspx?idCliente={idCliente}");
            }
            else
            {
                // Mostrar un mensaje si no se seleccionó ningún cliente.
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Seleccione un cliente para modificar.');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Valida si hay un cliente seleccionado.
            if (gvClientes.SelectedRow != null)
            {
                int idCliente = Convert.ToInt32(gvClientes.SelectedRow.Cells[0].Text);
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                try
                {
                    clienteNegocio.eliminarCliente(idCliente);
             
                    CargarClientes();
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Cliente eliminado con éxito.');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al eliminar cliente: {ex.Message}');", true);
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Seleccione un cliente para eliminar.');", true);
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
